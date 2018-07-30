using System;

namespace OYASAR.Framework.PubSub.Core.Model
{
    public class EventWrapper
    {
        public Type Type { get; set; }

        public string Json { get; set; }
    }
}
