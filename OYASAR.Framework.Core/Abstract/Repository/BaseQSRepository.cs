using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OYASAR.Framework.Core.CustomType;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Abstract.Repository
{
    public abstract class BaseQSRepository<TRepositoryProvider, TEntity, ModelKey> : BaseCommonRepository<TRepositoryProvider, ModelKey>, IBaseQSRepository<TRepositoryProvider, TEntity, ModelKey> 
        where TRepositoryProvider : class, IRepository where TEntity : class, ModelKey where ModelKey : class
    {
        public Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TBusinessObject>(Expression<Func<TEntity, bool>> expr)
             where TBusinessObject : class
        {
            return base.GetAllQ<TEntity, TBusinessObject>(expr);
        }

        public new Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TBusinessObject>()  where TBusinessObject : class
        {
            return base.GetAllQ<TEntity, TBusinessObject>();
        }

        public Queryable<TRepositoryProvider, TEntity> GetAllQ(Expression<Func<TEntity, bool>> expr)
        {
            return base.GetAllQ(expr);
        }

        public Queryable<TRepositoryProvider, TEntity> GetAllQ() 
        {
            return base.GetAllQ<TEntity>();
        }

        public IQueryable<TBusinessObject> GetAll<TBusinessObject>(Expression<Func<TEntity, bool>> expr) where TBusinessObject : class
        {
            return base.GetAll<TEntity, TBusinessObject>(expr);
        }

        public new IQueryable<TBusinessObject> GetAll<TBusinessObject>()  where TBusinessObject : class
        {
            return base.GetAll<TEntity, TBusinessObject>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expr)
        {
            return base.GetAll(expr);
        }

        public IQueryable<TEntity> GetAll() 
        {
            return base.GetAll<TEntity>();
        }

        public new TBusinessObject GetByKey<TBusinessObject>(object key) where TBusinessObject : class
        {
            return base.GetByKey<TEntity, TBusinessObject>(key);
        }

        public TEntity GetByKey(object key)
        {
            return base.GetByKey<TEntity>(key);
        }

        public void LazyLoad<TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TK : class
        {
            base.LazyLoad(entity, expr);
        }

        public void LazyLoad<TK>(TEntity entity) where TK : class
        {
            base.LazyLoad<TEntity, TK>(entity);
        }

        public void Add<TId>(TEntity dataObject)
        {
            base.Add<TEntity, TId>(dataObject);
        }

        public void Edit<TId>(TEntity dataObject) 
        {
            base.Edit<TEntity, TId>(dataObject);
        }

        public void Delete<TId>(TEntity dataObject)
        {
            base.Delete<TEntity, TId>(dataObject);
        }

        public void RowDelete(object key)
        {
            base.RowDelete<TEntity>(key);
        }

        public new void Save()
        {
            base.Save();
        }

        public IQueryable<TEntity> SqlQuery(string str, params object[] obj)
        {
            return base.SqlQuery<TEntity>(str, obj);
        }

        public async Task<IList<TBusinessObject>> GetAllAsync<TBusinessObject>(Expression<Func<TEntity, bool>> expr)
             where TBusinessObject : class
        {
            return await base.GetAllAsync<TEntity, TBusinessObject>(expr);
        }

        public new async Task<IList<TBusinessObject>> GetAllAsync<TBusinessObject>()  where TBusinessObject : class
        {
            return await base.GetAllAsync<TEntity, TBusinessObject>();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expr)
        {
            return await base.GetAllAsync(expr);
        }

        public async Task<IList<TEntity>> GetAllAsync() 
        {
            return await base.GetAllAsync<TEntity>();
        }

        public new async Task<TBusinessObject> GetByKeyAsync<TBusinessObject>(object key) where TBusinessObject : class
        {
            return await base.GetByKeyAsync<TEntity, TBusinessObject>(key);
        }

        public async Task<TEntity> GetByKeyAsync(object key) 
        {
            return await base.GetByKeyAsync<TEntity>(key);
        }

        public async Task LazyLoadAsync<TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TK : class
        {
            await base.LazyLoadAsync(entity, expr);
        }

        public async Task LazyLoadAsync<TK>(TEntity entity) where TK : class
        {
            await base.LazyLoadAsync<TEntity, TK>(entity);
        }

        public new async Task SaveAsync()
        {
            await base.SaveAsync();
        }

        public async Task<IList<TEntity>> SqlQueryAsync(string str, params object[] obj) 
        {
            return await base.SqlQueryAsync<TEntity>(str, obj);
        }

        public async Task<IList<TEntity>> GetListAsync(IQueryable<TEntity> queryable)
        {
            return await base.GetListAsync(queryable);
        }

        public async Task<TEntity> GetSingleOrDefaultAsync(IQueryable<TEntity> queryable) 
        {
            return await base.GetSingleOrDefaultAsync(queryable);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(IQueryable<TEntity> queryable) 
        {
            return await base.GetFirstOrDefaultAsync(queryable);
        }
    }
}
