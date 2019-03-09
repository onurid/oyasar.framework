namespace OYASAR.Framework.Core.Interface
{
    public interface IBaseRepository<ModelKey> : IBaseReadableRepository<ModelKey>, IBaseWritableRepository<ModelKey> where ModelKey : class
    {

    }
}
