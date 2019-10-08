using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OYASAR.Framework.Core.CustomType;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Abstract
{
    public abstract class BaseQSReadableRepository<TRepositoryProvider, TEntity, ModelKey> : BaseCommonRepository<TRepositoryProvider, ModelKey>, IBaseReadableRepository<TRepositoryProvider, TEntity, ModelKey>
        where TEntity : class, ModelKey where TRepositoryProvider : class, IRepository where ModelKey : class
    {
        public Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TBusinessObject>(Expression<Func<TEntity, bool>> expr)
           where TBusinessObject : class
        {
            return base.GetAllQ<TEntity, TBusinessObject>(expr);
        }

        public new Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TBusinessObject>() where TBusinessObject : class
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

        public IQueryable<TBusinessObject> GetAll<TBusinessObject>(Expression<Func<TEntity, bool>> expr)
            where TBusinessObject : class
        {
            return base.GetAll<TEntity, TBusinessObject>(expr);
        }

        public new IQueryable<TBusinessObject> GetAll<TBusinessObject>() where TBusinessObject : class
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

        public void LazyLoad<TK>(TEntity entity)
            where TK : class
        {
            base.LazyLoad<TEntity, TK>(entity);
        }

        public async Task<IList<TBusinessObject>> GetAllAsync<TBusinessObject>(Expression<Func<TEntity, bool>> expr)
            where TBusinessObject : class
        {
            return await base.GetAllAsync<TEntity, TBusinessObject>(expr);
        }

        public new async Task<IList<TBusinessObject>> GetAllAsync<TBusinessObject>() where TBusinessObject : class
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

        //public new async Task<IList<TEntity>> GetListAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        //{
        //    return await base.GetListAsync(queryable);
        //}

        //public new async Task<TEntity> GetSingleOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        //{
        //    return await base.GetSingleOrDefaultAsync(queryable);
        //}

        //public new async Task<TEntity> GetFirstOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        //{
        //    return await base.GetFirstOrDefaultAsync(queryable);
        //}
    }
}
