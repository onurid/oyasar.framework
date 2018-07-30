using System;
using Microsoft.AspNet.SignalR.Client;

namespace OYASAR.Framework.PubSub.Core.Model
{
    public class HubContainer
    {
        public Guid ContainerId { get; set; }
        public HubConnection HubConnection { get; set; }        
        public ConnectionStatus Status { get; set; }
    }

    public enum ConnectionStatus
    {
        Open,
        Closed,
        Connecting,
        Unknown
    }    
}
