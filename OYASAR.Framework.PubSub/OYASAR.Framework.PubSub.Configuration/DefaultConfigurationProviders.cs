using OYASAR.Framework.PubSub.Configuration.Base;

namespace OYASAR.Framework.PubSub.Configuration
{
    public class DefaultServerConfigurationProvider : ConfigurationProvider, IServerConfigurationProvider
    {
        public string Url { get; set; }
        
        /// <summary>
        /// When it run SignalR before, Definition of RunSignalR Conneciton Url
        /// </summary>
        /// <param name="url"></param>
        public DefaultServerConfigurationProvider(string url)
        {
            Url = url;
        }

        /// <summary>
        /// This Constrcuture, it use, when SignalR started.
        /// </summary>
        public DefaultServerConfigurationProvider()
        {
            
        }
    }

    public class DefaultClientConfigurationProvider : ConfigurationProvider, IClientConfigurationProvider
    {

    }
}
