using OYASAR.Framework.PubSub.Core.Persistence;
using Microsoft.Practices.Prism.PubSubEvents;

namespace OYASAR.Framework.PubSub.Core.Utils
{
    public class ClientPrismEventAggregatorShim : IClientEventShim
    {
        private readonly IEventAggregator _prismEventAggregator;

        public ClientPrismEventAggregatorShim(IEventAggregator prismEventAggregator)
        {
            _prismEventAggregator = prismEventAggregator;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IPubSubEvent
        {
            _prismEventAggregator.GetEvent<PubSubEvent<TEvent>>().Publish(@event);
        }
    }
}