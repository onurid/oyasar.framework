namespace OYASAR.Framework.Core.Interface
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set(string key, object data, int cacheTime);
    }
}
