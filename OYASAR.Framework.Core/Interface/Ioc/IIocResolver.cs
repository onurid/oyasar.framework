namespace OYASAR.Framework.Core.Interface
{
    public interface IIocResolver
    {
        object Resolve(object obj);
        T Resolve<T>() where T : class;

        object Resolve(object obj, string impKeyName);
        T Resolve<T>(string impKeyName) where T : class;
    }
}