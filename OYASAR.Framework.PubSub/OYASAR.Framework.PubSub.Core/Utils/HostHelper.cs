using System.Net;

namespace OYASAR.Framework.PubSub.Core.Utils
{
    public static class HostHelper
    {
        public static string GetHostName()
        {
            return Dns.GetHostName();
        }
    }
}
