using System.Collections.Generic;

namespace OYASAR.Framework.PubSub.Configuration.Base
{
    public interface IConfigurationProvider
    {
        IEnumerable<string> GetAll();
    }
}