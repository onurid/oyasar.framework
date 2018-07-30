using System.Collections.Generic;

namespace OYASAR.Framework.PubSub.Core.Model
{
    public class Package
    {

        public string Command { get; set; }
        public string Context { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}
