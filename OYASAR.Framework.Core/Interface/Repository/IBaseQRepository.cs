namespace OYASAR.Framework.Core.Interface
{
    public interface IBaseQRepository<TRepositoryProvider, ModelKey> : IBaseReadableRepository<TRepositoryProvider, ModelKey>, IBaseWritableRepository<ModelKey>
        where TRepositoryProvider : class, IRepository where ModelKey : class
    {

    }
}
