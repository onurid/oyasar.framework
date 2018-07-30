using System;
using OYASAR.Framework.PubSub.Core.Persistence;
using Microsoft.Practices.Prism.PubSubEvents;

namespace OYASAR.Framework.PubSub.Server.Base
{
    internal class ServerPrismEventAggregatorShim : IServerEventShim
    {
        private readonly IEventAggregator _prismEventAggregator;

        public Action<IPubSubEvent> BroadcastAction { get; set; }

        public ServerPrismEventAggregatorShim(IEventAggregator prismEventAggregator)
        {
            _prismEventAggregator = prismEventAggregator;

            _prismEventAggregator.GetEvent<PubSubEvent<IPubSubEvent>>().Subscribe(e =>
            {
                if (BroadcastAction != null)
                {
                    BroadcastAction(e);
                }
            });
        }
    }
}