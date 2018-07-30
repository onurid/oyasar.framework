using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using OYASAR.Framework.PubSub.Configuration;
using OYASAR.Framework.PubSub.Core.Event;
using OYASAR.Framework.PubSub.Core.Model;
using OYASAR.Framework.PubSub.Core.Persistence;
using OYASAR.Framework.PubSub.Core.Utils;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Practices.Prism.PubSubEvents;
using Newtonsoft.Json;

namespace OYASAR.Framework.PubSub.Client
{
    public class ClientManager : IClientManager
    {
        #region Private Properties

        private readonly string _hubName;

        private IHubProxy _hubProxy;
        private IClientEventShim _shim;

        private readonly List<HubContainer> _containerList;
        private readonly IEnumerable<string> _urlList;

        private Timer _timer = null;

        private int _selectedItem = 0;
        private bool _statusForLoopTry = false;

        private readonly IDictionary<string, IList<IListener>> _channelList;

        #endregion
        
        public ClientManager(string hubName, string providerName)
        {
            //var configProvider = CommonServiceLocator<IClientConfigurationProvider>.GetService(providerName);

            IClientConfigurationProvider configProvider = null;

            this._hubName = hubName;

            this._urlList = configProvider.GetAll();
            this._containerList = new List<HubContainer>();
            this._channelList = new Dictionary<string, IList<IListener>>();
        }

        public void Start()
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

            TryConnnect(_containerList[_selectedItem]);

            _timer = new Timer(CheckAnyoneConnection, null, 5000, 1000);
        }

        public void RegisterListener(string listenerName, IListener listener)
        {
            if (_channelList.ContainsKey(listenerName))
            {
                _channelList[listenerName].Add(listener);
                return;
            }

            _channelList.Add(listenerName, new List<IListener> { listener });
        }

        public IEnumerable<IListener> FetchListener(string listenerName)
        {
            return _channelList.FirstOrDefault(x => x.Key == listenerName).Value;
        }

        public void UnRegisterListener(string listenerName, IListener listener)
        {
            if (_channelList != null)
            {
                if (_channelList.ContainsKey(listenerName))
                {
                    _channelList[listenerName].Remove(listener);

                    if (!_channelList[listenerName].Any())
                        _channelList.Remove(listenerName);
                }
            }
        }


        #region Private Methods

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
                Console.WriteLine("kaoandı");
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

        private void CheckAnyoneConnection(object state)
        {
            if (_containerList[_selectedItem].Status == ConnectionStatus.Closed)
            {
                _containerList[_selectedItem].HubConnection.Stop();

                _selectedItem++;

                if (_selectedItem == _containerList.Count)
                {
                    _selectedItem = 0;

                    if (!_statusForLoopTry)
                        _statusForLoopTry = true;
                }

                if (!_statusForLoopTry)
                    TryConnnect(_containerList[_selectedItem]);
                else
                {
                    _containerList[_selectedItem].HubConnection.Start();
                    _containerList[_selectedItem].Status = ConnectionStatus.Connecting;
                }
            }
            else
                CheckSpecificStatus(_containerList[_selectedItem]);
        }

        private void TryConnnect(HubContainer container)
        {
            var prismEventAggregator = new EventAggregator();

            prismEventAggregator.GetEvent<PubSubEvent<ChannelEvent>>().Subscribe(ChannelEventAction);

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

        private bool Disposed = false;
       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        private void ChannelEventAction(ChannelEvent channelEvent)
        {
            var listeners = FetchListener(channelEvent.Channel);

            if (listeners != null)
            {
                foreach (var listener in listeners)
                {
                    listener.Notify(channelEvent.Package);
                }
            }
        }

        #endregion
    }
}
