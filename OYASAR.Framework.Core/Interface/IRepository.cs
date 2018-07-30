using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OYASAR.Framework.Core.Interface
{
    public interface IRepository : IDisposable
    {
        TEntity Add<TEntity>(TEntity t) where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity GetByKey<TEntity>(object key) where TEntity : class;
        TEntity DeleteByKey<TEntity>(object key) where TEntity : class;
        void Edit<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> SqlQuery<TEntity>(string str, params object[] obj) where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> expr) where TEntity : class;
        void LazyLoad<TEntity, K>(TEntity entity, Expression<Func<TEntity, ICollection<K>>> expr) where TEntity : class where K : class;
        void LazyLoad<TEntity, K>(TEntity entity, Expression<Func<TEntity, IEnumerable<K>>> expr) where TEntity : class where K : class;
        void LazyLoad<TEntity, K>(TEntity entity) where TEntity : class where K : class;
        void Save();
        
        Task<IList<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
        Task<TEntity> GetByKeyAsync<TEntity>(object key) where TEntity : class;
        Task<IList<TEntity>> SqlQueryAsync<TEntity>(string str, params object[] obj) where TEntity : class;
        Task<IList<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> expr) where TEntity : class;
        Task LazyLoadAsync<TEntity, K>(TEntity entity, Expression<Func<TEntity, ICollection<K>>> expr) where TEntity : class where K : class;
        Task LazyLoadAsync<TEntity, K>(TEntity entity, Expression<Func<TEntity, IEnumerable<K>>> expr) where TEntity : class where K : class;
        Task LazyLoadAsync<TEntity, K>(TEntity entity) where TEntity : class where K : class;
        Task SaveAsync();

        Task<IList<TEntity>> GetListAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
        Task<TEntity> GetSingleOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
        Task<TEntity> GetFirstOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
    }

    /// <summary>
    /// IRepository<TContext> / IRepository<TSession>
    /// </summary>
    /// <typeparam name="TContext">IRepository<TContext> / IRepository<TSession></typeparam>
    public interface IRepository<TContext> : IRepository
    {

    }
}