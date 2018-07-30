namespace OYASAR.Framework.Core.Interface
{
    public interface IBaseQSRepository<TRepositoryProvider, TEntity> : IBaseReadableRepository<TRepositoryProvider, TEntity>, IBaseWritableRepository<TEntity>
        where TRepositoryProvider : class, IRepository where TEntity : class
    {

    }
}
