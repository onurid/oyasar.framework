using OYASAR.Framework.PubSub.Core.Model;
using Owin;

namespace OYASAR.Framework.PubSub.Core.Persistence
{
    public interface IServerManager : IManager
    {
        /// <summary>
        /// Publish Client's & Api's
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="data"></param>
        void Publish(string channelName, Package data);

        /// <summary>
        /// Start RunSignalR Server
        /// </summary>
        /// <param name="app"></param>
        void Start(IAppBuilder app);
    }
}
