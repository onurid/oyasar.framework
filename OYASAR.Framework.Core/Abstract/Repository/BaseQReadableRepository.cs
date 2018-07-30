using OYASAR.Framework.Core.CustomType;
using OYASAR.Framework.Core.Interface;
using System;
using System.Linq.Expressions;

namespace OYASAR.Framework.Core.Abstract
{
    public abstract class BaseQReadableRepository<TRepositoryProvider> : BaseReadableRepository<TRepositoryProvider>, IBaseReadableRepository<TRepositoryProvider> where TRepositoryProvider : class, IRepository
    {
        public new Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class where TBusinessObject : class
        {
            return base.GetAllQ<TDataObject, TBusinessObject>(expr);
        }

        public new Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TDataObject, TBusinessObject>() where TDataObject : class where TBusinessObject : class
        {
            return base.GetAllQ<TDataObject, TBusinessObject>();
        }

        public new Queryable<TRepositoryProvider, TPoco> GetAllQ<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class
        {
            return base.GetAllQ(expr);
        }

        public new Queryable<TRepositoryProvider, TPoco> GetAllQ<TPoco>() where TPoco : class
        {
            return base.GetAllQ<TPoco>();
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
