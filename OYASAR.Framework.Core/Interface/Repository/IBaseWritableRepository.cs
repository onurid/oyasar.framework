using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OYASAR.Framework.Core.Interface
{
    public interface IBaseWritableRepository
    {
        void Add<TEntity, TId>(TEntity entity) where TEntity : class;
        void Edit<TEntity, TId>(TEntity entity) where TEntity : class;
        void Delete<TEntity, TId>(TEntity entity) where TEntity : class;
        void RowDelete<TEntity>(object key) where TEntity : class;
        void Save();
        IQueryable<TEntity> SqlQuery<TEntity>(string str, params object[] obj) where TEntity : class;

        Task SaveAsync();
        Task<IList<TEntity>> SqlQueryAsync<TEntity>(string str, params object[] obj) where TEntity : class;
    }

    public interface IBaseWritableRepository<TEntity> where TEntity : class
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
