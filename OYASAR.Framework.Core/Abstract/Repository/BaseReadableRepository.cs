﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Abstract
{
    public abstract class BaseReadableRepository<TRepositoryProvider, ModelKey> : BaseCommonRepository<TRepositoryProvider, ModelKey>, IBaseReadableRepository<ModelKey> where TRepositoryProvider : class, IRepository where ModelKey : class
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
