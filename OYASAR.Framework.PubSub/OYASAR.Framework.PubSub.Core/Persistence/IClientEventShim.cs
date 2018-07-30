namespace OYASAR.Framework.PubSub.Core.Persistence
{
    public interface IClientEventShim
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IPubSubEvent;
    }
}
