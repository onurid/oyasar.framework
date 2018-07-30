using Newtonsoft.Json;

namespace OYASAR.Framework.Utils.Helper
{
    public static class JsonHelper
    {
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T Deserialize<T>(string strJson)
        {
            return JsonConvert.DeserializeObject<T>(strJson);
        }
    }
}
