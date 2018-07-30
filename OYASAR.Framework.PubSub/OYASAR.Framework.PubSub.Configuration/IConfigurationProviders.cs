using OYASAR.Framework.PubSub.Configuration.Base;

namespace OYASAR.Framework.PubSub.Configuration
{
    public interface IServerConfigurationProvider : IConfigurationProvider
    {
        /// <summary>
        /// SignalR Server Url: someting like that "/signalr"
        /// </summary>
        string Url { get; set; }
    }

    public interface IClientConfigurationProvider : IConfigurationProvider
    {
        
    }
}