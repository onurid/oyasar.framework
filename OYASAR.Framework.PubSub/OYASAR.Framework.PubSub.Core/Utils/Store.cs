using System;

namespace OYASAR.Framework.PubSub.Core.Utils
{
    public static class Store
    {
        static Store()
        {
            Id = Guid.NewGuid();
        }

        public static Guid Id { get; set; }
    }
}
