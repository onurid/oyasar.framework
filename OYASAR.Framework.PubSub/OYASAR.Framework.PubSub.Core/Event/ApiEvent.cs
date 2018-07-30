using System;
using System.Collections.Generic;
using OYASAR.Framework.PubSub.Core.Persistence;

namespace OYASAR.Framework.PubSub.Core.Event
{
    public class ApiEvent : IPubSubEvent
    {
        public ApiEvent(Guid yourId)
        {
            IdList = new List<Guid> { yourId };

            MoveNext = true;
        }

        public void AddMyId(Guid id)
        {
            IdList.Add(id);
        }

        public bool MoveNext { get; set; }

        public IList<Guid> IdList { get; private set; }
        public ChannelEvent ChannelEvent { get; set; }
    }
}
