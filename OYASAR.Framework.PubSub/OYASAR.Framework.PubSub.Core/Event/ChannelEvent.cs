using OYASAR.Framework.PubSub.Core.Model;
using OYASAR.Framework.PubSub.Core.Persistence;

namespace OYASAR.Framework.PubSub.Core.Event
{
    public class ChannelEvent : IPubSubEvent
    {
        public Package Package { get; set; }

        public string Channel { get; set; }
    }
}
