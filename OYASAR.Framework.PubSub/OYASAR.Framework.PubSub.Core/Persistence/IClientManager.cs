using System.Collections.Generic;

namespace OYASAR.Framework.PubSub.Core.Persistence
{
    public interface IClientManager : IManager
    {
        /// <summary>
        /// Start ClientManager
        /// </summary>
        void Start();

        /// <summary>
        /// RegisterListener
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="listener"></param>
        void RegisterListener(string channel, IListener listener);

        /// <summary>
        /// FetchListener
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        IEnumerable<IListener> FetchListener(string channel);

        /// <summary>
        /// UnRegisterListener
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="listener"></param>
        void UnRegisterListener(string channel, IListener listener);
    }
}
