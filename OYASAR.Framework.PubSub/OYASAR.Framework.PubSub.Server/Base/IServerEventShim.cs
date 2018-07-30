using System;
using OYASAR.Framework.PubSub.Core.Persistence;

namespace OYASAR.Framework.PubSub.Server.Base
{
    public interface IServerEventShim
    {
        Action<IPubSubEvent> BroadcastAction { get; set; }
    }
}
