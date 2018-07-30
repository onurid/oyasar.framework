using System.Configuration;

namespace OYASAR.Framework.PubSub.Configuration
{
    public class PubSubConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("mappings", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(PubSubApiServerConfiguration), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public PubSubApiServerConfiguration Configs
        {
            get
            {
                return (PubSubApiServerConfiguration)base["mappings"];
            }
        }

        public PubSubConfigurationSection()
        {
            PubSubConfig url = new PubSubConfig();
            Configs.Add(url);
        }

        public static PubSubConfigurationSection Configurations
        {
            get
            {
                return ConfigurationManager.GetSection("pubSubConfiguration") as PubSubConfigurationSection;
            }
        }
    }

    public class PubSubApiServerConfiguration : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new PubSubConfig();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PubSubConfig)element).Name;
        }

        public PubSubConfig this[int index]
        {
            get
            {
                return (PubSubConfig)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public new PubSubConfig this[string name]
        {
            get
            {
                return (PubSubConfig)BaseGet(name);
            }
        }

        public int IndexOf(PubSubConfig setting)
        {
            return BaseIndexOf(setting);
        }

        public void Add(PubSubConfig setting)
        {
            BaseAdd(setting);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(PubSubConfig setting)
        {
            if (BaseIndexOf(setting) >= 0)
            {
                BaseRemove(setting.Name);
            }
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }

    public class PubSubConfig : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get
            {
                return (string)this["value"];
            }
        }
    }
}
