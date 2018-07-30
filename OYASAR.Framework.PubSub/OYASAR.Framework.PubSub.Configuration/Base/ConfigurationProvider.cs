using System.Collections.Generic;
using OYASAR.Framework.PubSub.Core.Utils;

namespace OYASAR.Framework.PubSub.Configuration.Base
{
    public abstract class ConfigurationProvider : IConfigurationProvider
    {
        public virtual IEnumerable<string> GetAll()
        {
            foreach (var config in PubSubConfigurationSection.Configurations.Configs)
            {
                var item = (PubSubConfig)config;

                if (item.Name != HostHelper.GetHostName())
                    yield return item.Value;
            }
        }
    }
}
