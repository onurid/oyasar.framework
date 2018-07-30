namespace OYASAR.Framework.Core.Interface
{
    public interface IIocResolver
    {
        object Resolve(object obj);
        T Resolve<T>() where T : class;
    }
}