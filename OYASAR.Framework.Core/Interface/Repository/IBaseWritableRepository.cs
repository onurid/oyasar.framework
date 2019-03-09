using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OYASAR.Framework.Core.Interface
{
    public interface IBaseWritableRepository<ModelKey> where ModelKey : class
    {
        void Add<TEntity, TId>(TEntity entity) where TEntity : class, ModelKey;
        void Edit<TEntity, TId>(TEntity entity) where TEntity : class, ModelKey;
        void Delete<TEntity, TId>(TEntity entity) where TEntity : class, ModelKey;
        void RowDelete<TEntity>(object key) where TEntity : class, ModelKey;
        void Save();
        IQueryable<TEntity> SqlQuery<TEntity>(string str, params object[] obj) where TEntity : class, ModelKey;

        Task SaveAsync();
        Task<IList<TEntity>> SqlQueryAsync<TEntity>(string str, params object[] obj) where TEntity : class, ModelKey;
    }

    public interface IBaseWritableRepository<TEntity, ModelKey> where TEntity : class, ModelKey where ModelKey : class
    {
        void Add<TId>(TEntity entity);
        void Edit<TId>(TEntity entity);
        void Delete<TId>(TEntity entity);
        void RowDelete(object key);
        void Save();
        IQueryable<TEntity> SqlQuery(string str, params object[] obj);

        Task SaveAsync();
        Task<IList<TEntity>> SqlQueryAsync(string str, params object[] obj);
    }
}
