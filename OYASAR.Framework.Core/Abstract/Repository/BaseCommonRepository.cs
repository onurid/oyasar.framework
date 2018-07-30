using OYASAR.Framework.Core.Extensions;
using OYASAR.Framework.Core.Helper;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OYASAR.Framework.Core.CustomType;

namespace OYASAR.Framework.Core.Abstract
{
    public abstract class BaseCommonRepository<TRepositoryProvider> where TRepositoryProvider : class, IRepository
    {
        private readonly TRepositoryProvider _repository;

        protected internal BaseCommonRepository()
        {
            this._repository = Invoke<TRepositoryProvider>.Call();
        }

        internal virtual Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class where TBusinessObject : class
        {
            var data = _repository.GetAll(expr);

            var result = data.MapTo<TBusinessObject>();

            return result.ToQueryable(_repository);
        }

        internal virtual Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TDataObject, TBusinessObject>() where TDataObject : class where TBusinessObject : class
        {
            var data = _repository.GetAll<TDataObject>();

            var result = data.MapTo<TBusinessObject>();

            return result.ToQueryable(_repository);
        }

        internal virtual Queryable<TRepositoryProvider, TPoco> GetAllQ<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class
        {
            return _repository.GetAll(expr).ToQueryable(_repository);
        }

        internal virtual Queryable<TRepositoryProvider, TPoco> GetAllQ<TPoco>() where TPoco : class
        {
            return _repository.GetAll<TPoco>().ToQueryable(_repository);
        }

        internal virtual IQueryable<TBusinessObject> GetAll<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class where TBusinessObject : class
        {
            var data = _repository.GetAll(expr);

            var result = data.MapTo<TBusinessObject>();

            return result;
        }

        internal virtual IQueryable<TBusinessObject> GetAll<TDataObject, TBusinessObject>() where TDataObject : class where TBusinessObject : class
        {
            var data = _repository.GetAll<TDataObject>();

            var result = data.MapTo<TBusinessObject>();

            return result;
        }

        internal virtual IQueryable<TPoco> GetAll<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class
        {
            return _repository.GetAll(expr);
        }

        internal virtual IQueryable<TPoco> GetAll<TPoco>() where TPoco : class
        {
            return _repository.GetAll<TPoco>();
        }

        internal virtual TBusinessObject GetByKey<TDataObject, TBusinessObject>(object key) where TDataObject : class where TBusinessObject : class
        {
            var data = _repository.GetByKey<TDataObject>(key);

            var result = data.MapTo<TBusinessObject>();

            return result;
        }

        internal virtual TPoco GetByKey<TPoco>(object key) where TPoco : class
        {
            return _repository.GetByKey<TPoco>(key);
        }

        internal virtual void LazyLoad<TEntity, TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TEntity : class where TK : class
        {
            _repository.LazyLoad(entity, expr);
        }

        internal virtual void LazyLoad<TEntity, TK>(TEntity entity)
            where TEntity : class
            where TK : class
        {
            _repository.LazyLoad<TEntity, TK>(entity);
        }

        internal virtual void Add<TDataObject, TId>(TDataObject dataObject) where TDataObject : class
        {
            var baseAuditHelper = new BaseAuditHelper<TDataObject, TId>(dataObject, BaseAuditHelper<TDataObject, TId>.BaseAuditType.Create, true);

            _repository.Add(dataObject);
        }

        internal virtual void Edit<TDataObject, TId>(TDataObject dataObject) where TDataObject : class
        {
            var baseAuditHelper = new BaseAuditHelper<TDataObject, TId>(dataObject, BaseAuditHelper<TDataObject, TId>.BaseAuditType.Modify);

            _repository.Edit(dataObject);
        }

        internal virtual void Delete<TDataObject, TId>(TDataObject dataObject) where TDataObject : class
        {
            var baseAuditHelper = new BaseAuditHelper<TDataObject, TId>(dataObject, BaseAuditHelper<TDataObject, TId>.BaseAuditType.Delete);

            _repository.Edit(dataObject);
        }

        internal virtual void RowDelete<TDataObject>(object key) where TDataObject : class
        {
            _repository.DeleteByKey<TDataObject>(key);
        }

        internal virtual void Save()
        {
            _repository.Save();
        }

        internal virtual IQueryable<TEntity> SqlQuery<TEntity>(string str, params object[] obj) where TEntity : class
        {
            return _repository.SqlQuery<TEntity>(str, obj);
        }

        internal virtual async Task<IList<TBusinessObject>> GetAllAsync<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class where TBusinessObject : class
        {
            var data = await _repository.GetAllAsync(expr);

            var result = data.MapTo<IList<TBusinessObject>>();

            return result;
        }

        internal virtual async Task<IList<TBusinessObject>> GetAllAsync<TDataObject, TBusinessObject>() where TDataObject : class where TBusinessObject : class
        {
            var data = await _repository.GetAllAsync<TDataObject>();

            var result = data.MapTo<IList<TBusinessObject>>();

            return result;
        }

        internal virtual async Task<IList<TPoco>> GetAllAsync<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class
        {
            return await _repository.GetAllAsync(expr);
        }

        internal virtual async Task<IList<TPoco>> GetAllAsync<TPoco>() where TPoco : class
        {
            return await _repository.GetAllAsync<TPoco>();
        }

        internal virtual async Task<TBusinessObject> GetByKeyAsync<TDataObject, TBusinessObject>(object key) where TDataObject : class where TBusinessObject : class
        {
            var data = await _repository.GetByKeyAsync<TDataObject>(key);

            var result = data.MapTo<TBusinessObject>();

            return result;
        }

        internal virtual async Task<TPoco> GetByKeyAsync<TPoco>(object key) where TPoco : class
        {
            return await _repository.GetByKeyAsync<TPoco>(key);
        }

        internal virtual async Task LazyLoadAsync<TEntity, TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TEntity : class where TK : class
        {
            await _repository.LazyLoadAsync(entity, expr);
        }

        internal virtual async Task LazyLoadAsync<TEntity, TK>(TEntity entity)
            where TEntity : class
            where TK : class
        {
            await _repository.LazyLoadAsync<TEntity, TK>(entity);
        }       

        internal virtual async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        internal virtual async Task<IList<TEntity>> SqlQueryAsync<TEntity>(string str, params object[] obj) where TEntity : class
        {
            return await _repository.SqlQueryAsync<TEntity>(str, obj);
        }

        internal virtual async Task<IList<TEntity>> GetListAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return await _repository.GetListAsync(queryable);
        }

        internal virtual async Task<TEntity> GetSingleOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return await _repository.GetSingleOrDefaultAsync(queryable);
        }

        internal virtual async Task<TEntity> GetFirstOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return await _repository.GetFirstOrDefaultAsync(queryable);
        }
    }
}
