using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using OYASAR.Framework.PubSub.Configuration;
using OYASAR.Framework.PubSub.Core.Event;
using OYASAR.Framework.PubSub.Core.Model;
using OYASAR.Framework.PubSub.Core.Persistence;
using OYASAR.Framework.PubSub.Core.Utils;
using OYASAR.Framework.PubSub.Server.Base;
using OYASAR.Framework.PubSub.Server.Helper;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Owin.Cors;
using Microsoft.Practices.Prism.PubSubEvents;
using Newtonsoft.Json;
using Owin;

namespace OYASAR.Framework.PubSub.Server
{
    public class ServerManager : IServerManager
    {
        #region Private Feature

        private static readonly IList<string> _loadedHub = new List<string>();

        private readonly string _hubName;

        private readonly string _connectionUrl;

        private readonly IHubContext _context;

        private IHubProxy _hubProxy;
        private IClientEventShim _shim;

        private readonly List<HubContainer> _containerList;
        private readonly IEnumerable<string> _urlList;

        private Timer _timer = null;

        private readonly EventAggregator _prismEventAggregator;

        private bool Disposed = false;

        #endregion

        /// <summary>
        /// Default: 600
        /// </summary>
        public int ConnectionSecond { get; set; }

        /// <summary>
        /// Default: 10
        /// </summary>
        public int DisconnectionSecond { get; set; }

        /// <summary>
        /// Third Constructrue: requirement ConfiguraionProvider for another Api's
        /// </summary>
        /// <param name="hubname"></param>
        /// <param name="providerName"></param>
        public ServerManager(string hubname, string providerName)
        {
            //var configProvider = CommonServiceLocator<IServerConfigurationProvider>.GetService(providerName);

            IServerConfigurationProvider configProvider = null;

            this._hubName = hubname;
            this._connectionUrl = configProvider.Url;

            this.ConnectionSecond = 600;
            this.DisconnectionSecond = 10;

            this._urlList = configProvider.GetAll();
            this._containerList = new List<HubContainer>();
            
            this._prismEventAggregator = new EventAggregator();

            GlobalHost.Configuration.ConnectionTimeout = new TimeSpan(0, 0, ConnectionSecond);
            GlobalHost.Configuration.DisconnectTimeout = new TimeSpan(0, 0, DisconnectionSecond);
            
            RegisterShims(new[]
            {
                new ServerPrismEventAggregatorShim(_prismEventAggregator),
            });

            LoadHub();

            this._context = GlobalHost.ConnectionManager.GetHubContext(hubname);
        }

        /// <summary>
        /// Try connect another Api's and the SignalR server will be started!
        /// </summary>
        public void Start(IAppBuilder app)
        {
            RunSignalR(app);

            RunAnotherApiConnect();
        }

        /// <summary>
        /// Publish Client's & Api's
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="data"></param>
        public void Publish(string channelName, Package data)
        {
            PublishChannel(channelName, data);
            PublishApi(channelName, data);
        }

        public void RegisterShims(IEnumerable<IServerEventShim> shims)
        {
            foreach (var shim in shims)
            {
                shim.BroadcastAction = Broadcast;
            }
        }

        public void Broadcast(IPubSubEvent @event)
        {
            var eventWrapper = new EventWrapper
            {
                Type = @event.GetType(),
                Json = JsonConvert.SerializeObject(@event)
            };

            _context.Clients.All.PubSubBusEvent(eventWrapper);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Private Method

        private void LoadHub()
        {
            GenerateCode();
        }

        private void GenerateCode()
        {
            var factory = new PubSubHubFactory();

            if (!_loadedHub.Contains(_hubName))
            {
                if (factory.Run(_hubName))
                {
                    _loadedHub.Add(_hubName);
                }
            }
        }

        private void PublishChannel(string channelName, Package data)
        {
            var channelEvent = new ChannelEvent { Channel = channelName, Package = data };

            Publish(channelEvent);
        }

        private void PublishApi(string channelName, Package data)
        {
            var channelEvent = new ChannelEvent { Channel = channelName, Package = data };

            var apiEvent = new ApiEvent(Store.Id) { ChannelEvent = channelEvent };

            Publish(apiEvent);
        }
        
        private void Publish(IPubSubEvent signalREvent)
        {
            _prismEventAggregator.GetEvent<PubSubEvent<IPubSubEvent>>().Publish(signalREvent);
        }


        private void RunAnotherApiConnect()
        {
            foreach (var item in _urlList)
            {
                var container = new HubContainer
                {
                    ContainerId = Guid.NewGuid(),
                    HubConnection = new HubConnection(item),
                };

                AddEvents(container);

                _containerList.Add(container);
            }

            _containerList.ForEach(x => Task.Run(() => TryConnnect(x)));

            _timer = new Timer(CheckAllConnection, null, 5000, 10000);
        }

        private void RunSignalR(IAppBuilder app)
        {
            app.Map(
                _connectionUrl,
                map =>
                {
                    map.UseCors(CorsOptions.AllowAll);

                    var hubConfiguration = new HubConfiguration { EnableDetailedErrors = true };

                    map.RunSignalR(hubConfiguration);

                });
        }


        private void Initialise(HubConnection hubConnection, IClientEventShim clientEventShim)
        {
            _hubProxy = hubConnection.CreateHubProxy(_hubName);
            _hubProxy.On<EventWrapper>("PubSubBusEvent", EventReceived);
            _shim = clientEventShim;
        }

        private void EventReceived(EventWrapper eventWrapper)
        {
            var @event = JsonConvert.DeserializeObject(eventWrapper.Json, eventWrapper.Type) as IPubSubEvent;
            if (@event == null)
            {
                return;
            }

            var method = _shim.GetType().GetMethod("Publish", BindingFlags.Public | BindingFlags.Instance);
            method = method.MakeGenericMethod(eventWrapper.Type);
            method.Invoke(_shim, new object[] { @event });
        }

        private void AddEvents(HubContainer container)
        {
            container.HubConnection.Error += ex =>
            {
                container.Status = ConnectionStatus.Unknown;
            };

            container.HubConnection.Closed += () =>
            {
                container.Status = ConnectionStatus.Closed;
            };

            container.HubConnection.Reconnected += () =>
            {
                container.Status = ConnectionStatus.Open;
            };

            container.HubConnection.Reconnecting += () =>
            {
                container.Status = ConnectionStatus.Connecting;
            };
        }

        private void TryConnnect(HubContainer container)
        {
            var prismEventAggregator = new EventAggregator();

            prismEventAggregator.GetEvent<PubSubEvent<ApiEvent>>().Subscribe(ApiEventAction);

            try
            {
                var clientShim = new ClientPrismEventAggregatorShim(prismEventAggregator);

                Initialise(container.HubConnection, clientShim);

                container.HubConnection.Start().Wait();

            }
            catch (Exception ex) { }
        }

        private void CheckSpecificStatus(HubContainer container)
        {
            container.Status = container.HubConnection.State == ConnectionState.Connected ? ConnectionStatus.Open : container.Status;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                Disposed = true;
                if (disposing)
                {
                    _timer.Dispose();
                    _timer = null;

                    foreach (var container in _containerList)
                    {
                        container.HubConnection.Stop(new TimeSpan(100));
                        container.HubConnection = null;
                    }

                    _containerList.Clear();
                }
            }
        }

        private void CheckAllConnection(object state)
        {
            _containerList.ForEach(x =>
            {
                if (x.Status == ConnectionStatus.Closed)
                {
                    x.HubConnection.Start();

                    x.Status = ConnectionStatus.Connecting;
                }
                else
                    CheckSpecificStatus(x);
            });
        }

        private void ApiEventAction(ApiEvent apiEvent)
        {
            if (apiEvent.IdList.All(x => x != Store.Id))
            {
                apiEvent.AddMyId(Store.Id);

                if (apiEvent.MoveNext)
                {
                    apiEvent.MoveNext = false;
                }
                PublishChannel(apiEvent.ChannelEvent.Channel, apiEvent.ChannelEvent.Package);
            }
        }

        #endregion
    }
}
