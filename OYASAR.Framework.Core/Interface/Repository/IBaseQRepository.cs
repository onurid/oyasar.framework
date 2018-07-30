namespace OYASAR.Framework.Core.Interface
{
    public interface IBaseQRepository<TRepositoryProvider> : IBaseReadableRepository<TRepositoryProvider>, IBaseWritableRepository
        where TRepositoryProvider : class, IRepository
    {

    }
}
