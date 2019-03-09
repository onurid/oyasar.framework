namespace OYASAR.Framework.Core.Interface
{
    public interface IBaseQSRepository<TRepositoryProvider, TEntity, ModelKey> : IBaseReadableRepository<TRepositoryProvider, TEntity, ModelKey>, IBaseWritableRepository<TEntity, ModelKey>
        where TRepositoryProvider : class, IRepository where TEntity : class, ModelKey where ModelKey : class
    {

    }
}
