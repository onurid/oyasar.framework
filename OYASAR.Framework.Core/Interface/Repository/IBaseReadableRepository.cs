using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OYASAR.Framework.Core.CustomType;

namespace OYASAR.Framework.Core.Interface
{
    public interface IBaseReadableRepository
    {
        IQueryable<TBusinessObject> GetAll<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class where TBusinessObject : class;

        IQueryable<TBusinessObject> GetAll<TDataObject, TBusinessObject>() where TDataObject : class where TBusinessObject : class;

        IQueryable<TPoco> GetAll<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class;

        IQueryable<TPoco> GetAll<TPoco>() where TPoco : class;

        TBusinessObject GetByKey<TDataObject, TBusinessObject>(object key) where TDataObject : class where TBusinessObject : class;

        TPoco GetByKey<TPoco>(object key) where TPoco : class;

        void LazyLoad<TEntity, TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TEntity : class where TK : class;
        void LazyLoad<TEntity, TK>(TEntity entity) where TEntity : class where TK : class;


        Task<IList<TBusinessObject>> GetAllAsync<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class where TBusinessObject : class;

        Task<IList<TBusinessObject>> GetAllAsync<TDataObject, TBusinessObject>() where TDataObject : class where TBusinessObject : class;

        Task<IList<TPoco>> GetAllAsync<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class;

        Task<IList<TPoco>> GetAllAsync<TPoco>() where TPoco : class;

        Task<TBusinessObject> GetByKeyAsync<TDataObject, TBusinessObject>(object key) where TDataObject : class where TBusinessObject : class;

        Task<TPoco> GetByKeyAsync<TPoco>(object key) where TPoco : class;

        Task LazyLoadAsync<TEntity, TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TEntity : class where TK : class;
        Task LazyLoadAsync<TEntity, TK>(TEntity entity) where TEntity : class where TK : class;

        //Task<IList<TEntity>> GetListAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
        //Task<TEntity> GetSingleOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
        //Task<TEntity> GetFirstOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
    }

    public interface IBaseReadableRepository<TRepositoryProvider> where TRepositoryProvider : class, IRepository
    {
        Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class where TBusinessObject : class;

        Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TDataObject, TBusinessObject>() where TDataObject : class where TBusinessObject : class;

        Queryable<TRepositoryProvider, TPoco> GetAllQ<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class;

        Queryable<TRepositoryProvider, TPoco> GetAllQ<TPoco>() where TPoco : class;
        
        IQueryable<TBusinessObject> GetAll<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class where TBusinessObject : class;

        IQueryable<TBusinessObject> GetAll<TDataObject, TBusinessObject>() where TDataObject : class where TBusinessObject : class;

        IQueryable<TPoco> GetAll<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class;

        IQueryable<TPoco> GetAll<TPoco>() where TPoco : class;

        TBusinessObject GetByKey<TDataObject, TBusinessObject>(object key) where TDataObject : class where TBusinessObject : class;

        TPoco GetByKey<TPoco>(object key) where TPoco : class;

        void LazyLoad<TEntity, TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TEntity : class where TK : class;
        void LazyLoad<TEntity, TK>(TEntity entity) where TEntity : class where TK : class;


        Task<IList<TBusinessObject>> GetAllAsync<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class where TBusinessObject : class;

        Task<IList<TBusinessObject>> GetAllAsync<TDataObject, TBusinessObject>() where TDataObject : class where TBusinessObject : class;

        Task<IList<TPoco>> GetAllAsync<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class;

        Task<IList<TPoco>> GetAllAsync<TPoco>() where TPoco : class;

        Task<TBusinessObject> GetByKeyAsync<TDataObject, TBusinessObject>(object key) where TDataObject : class where TBusinessObject : class;

        Task<TPoco> GetByKeyAsync<TPoco>(object key) where TPoco : class;

        Task LazyLoadAsync<TEntity, TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TEntity : class where TK : class;
        Task LazyLoadAsync<TEntity, TK>(TEntity entity) where TEntity : class where TK : class;

        //Task<IList<TEntity>> GetListAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
        //Task<TEntity> GetSingleOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
        //Task<TEntity> GetFirstOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
    }

    public interface IBaseReadableRepository<TRepositoryProvider, TEntity> where TRepositoryProvider : class, IRepository where TEntity : class
    {
        Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TBusinessObject>(Expression<Func<TEntity, bool>> expr) where TBusinessObject : class;

        Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TBusinessObject>() where TBusinessObject : class;

        Queryable<TRepositoryProvider, TEntity> GetAllQ(Expression<Func<TEntity, bool>> expr);

        Queryable<TRepositoryProvider, TEntity> GetAllQ();

        IQueryable<TBusinessObject> GetAll<TBusinessObject>(Expression<Func<TEntity, bool>> expr)
            where TBusinessObject : class;

        IQueryable<TBusinessObject> GetAll<TBusinessObject>()  where TBusinessObject : class;

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expr);

        IQueryable<TEntity> GetAll();

        TBusinessObject GetByKey<TBusinessObject>(object key) where TBusinessObject : class;

        TEntity GetByKey(object key);

        void LazyLoad<TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TK : class;
        void LazyLoad<TK>(TEntity entity) where TK : class;


        Task<IList<TBusinessObject>> GetAllAsync<TBusinessObject>(Expression<Func<TEntity, bool>> expr)
            where TBusinessObject : class;

        Task<IList<TBusinessObject>> GetAllAsync<TBusinessObject>() where TBusinessObject : class;

        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expr);

        Task<IList<TEntity>> GetAllAsync() ;

        Task<TBusinessObject> GetByKeyAsync<TBusinessObject>(object key) where TBusinessObject : class;

        Task<TEntity> GetByKeyAsync(object key);

        Task LazyLoadAsync<TK>(TEntity entity, Expression<Func<TEntity, ICollection<TK>>> expr) where TK : class;
        Task LazyLoadAsync<TK>(TEntity entity) where TK : class;

        //Task<IList<TEntity>> GetListAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
        //Task<TEntity> GetSingleOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
        //Task<TEntity> GetFirstOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class;
    }
}
