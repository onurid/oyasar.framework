using OYASAR.Framework.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OYASAR.Framework.Core.Abstract
{
    public abstract class BaseRepository<TRepositoryProvider, ModelKey> : BaseCommonRepository<TRepositoryProvider, ModelKey>, IBaseRepository<ModelKey> where TRepositoryProvider : class, IRepository where ModelKey : class
    {
        public new IQueryable<TBusinessObject> GetAll<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class, ModelKey where TBusinessObject : class
        {
            return base.GetAll<TDataObject, TBusinessObject>(expr);
        }

        public new IQueryable<TBusinessObject> GetAll<TDataObject, TBusinessObject>() where TDataObject : class, ModelKey where TBusinessObject : class
        {
            return base.GetAll<TDataObject, TBusinessObject>();
        }

        public new IQueryable<TPoco> GetAll<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class, ModelKey
        {
            return base.GetAll(expr);
        }

        public new IQueryable<TPoco> GetAll<TPoco>() where TPoco : class, ModelKey
        {
            return base.GetAll<TPoco>();
        }

        public new TBusinessObject GetByKey<TDataObject, TBusinessObject>(object key) where TDataObject : class, ModelKey where TBusinessObject : class
        {
            return base.GetByKey<TDataObject, TBusinessObject>(key);
        }

        public new TPoco GetByKey<TPoco>(object key) where TPoco : class, ModelKey
        {
            return base.GetByKey<TPoco>(key);
        }

        public new void LazyLoad<TEntity, TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TEntity : class, ModelKey where TK : class
        {
            base.LazyLoad(entity, expr);
        }

        public new void LazyLoad<TEntity, TK>(TEntity entity)
            where TEntity : class, ModelKey
            where TK : class
        {
            base.LazyLoad<TEntity, TK>(entity);
        }

        public new void Add<TDataObject, TId>(TDataObject dataObject) where TDataObject : class, ModelKey
        {
            base.Add<TDataObject, TId>(dataObject);
        }

        public new void Edit<TDataObject, TId>(TDataObject dataObject) where TDataObject : class, ModelKey
        {
            base.Edit<TDataObject, TId>(dataObject);
        }

        public new void Delete<TDataObject, TId>(TDataObject dataObject) where TDataObject : class, ModelKey
        {
            base.Delete<TDataObject, TId>(dataObject);
        }

        public new void RowDelete<TDataObject>(object key) where TDataObject : class, ModelKey
        {
            base.RowDelete<TDataObject>(key);
        }

        public new void Save()
        {
            base.Save();
        }

        public new IQueryable<TEntity> SqlQuery<TEntity>(string str, params object[] obj) where TEntity : class, ModelKey
        {
            return base.SqlQuery<TEntity>(str, obj);
        }

        public new async Task<IList<TBusinessObject>> GetAllAsync<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class, ModelKey where TBusinessObject : class
        {
            return await base.GetAllAsync<TDataObject, TBusinessObject>(expr);
        }

        public new async Task<IList<TBusinessObject>> GetAllAsync<TDataObject, TBusinessObject>() where TDataObject : class, ModelKey where TBusinessObject : class
        {
            return await base.GetAllAsync<TDataObject, TBusinessObject>();
        }

        public new async Task<IList<TPoco>> GetAllAsync<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class, ModelKey
        {
            return await base.GetAllAsync(expr);
        }

        public new async Task<IList<TPoco>> GetAllAsync<TPoco>() where TPoco : class, ModelKey
        {
            return await base.GetAllAsync<TPoco>();
        }

        public new async Task<TBusinessObject> GetByKeyAsync<TDataObject, TBusinessObject>(object key) where TDataObject : class, ModelKey where TBusinessObject : class
        {
            return await base.GetByKeyAsync<TDataObject, TBusinessObject>(key);
        }

        public new async Task<TPoco> GetByKeyAsync<TPoco>(object key) where TPoco : class, ModelKey
        {
            return await base.GetByKeyAsync<TPoco>(key);
        }

        public new async Task LazyLoadAsync<TEntity, TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TEntity : class, ModelKey where TK : class
        {
            await base.LazyLoadAsync(entity, expr);
        }

        public new async Task LazyLoadAsync<TEntity, TK>(TEntity entity) where TEntity : class, ModelKey where TK : class
        {
            await base.LazyLoadAsync<TEntity, TK>(entity);
        }

        public new async Task SaveAsync()
        {
            await base.SaveAsync();
        }

        public new async Task<IList<TEntity>> SqlQueryAsync<TEntity>(string str, params object[] obj) where TEntity : class, ModelKey
        {
            return await base.SqlQueryAsync<TEntity>(str, obj);
        }

        public new async Task<IList<TEntity>> GetListAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class, ModelKey
        {
            return await base.GetListAsync(queryable);
        }

        public new async Task<TEntity> GetSingleOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class, ModelKey
        {
            return await base.GetSingleOrDefaultAsync(queryable);
        }

        public new async Task<TEntity> GetFirstOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class, ModelKey
        {
            return await base.GetFirstOrDefaultAsync(queryable);
        }
    }
}
