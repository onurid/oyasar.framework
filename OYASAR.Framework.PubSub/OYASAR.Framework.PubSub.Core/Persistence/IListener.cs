using OYASAR.Framework.PubSub.Core.Model;

namespace OYASAR.Framework.PubSub.Core.Persistence
{
    public interface IListener
    {
        void Notify(Package package);
    }
}
