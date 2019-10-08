using System;
using System.Linq.Expressions;
using OYASAR.Framework.Core.CustomType;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Abstract
{
    public abstract class BaseQRepository<TRepositoryProvider, ModelKey> : BaseRepository<TRepositoryProvider, ModelKey>, IBaseQRepository<TRepositoryProvider, ModelKey> where TRepositoryProvider : class, IRepository where ModelKey : class
    {
        public new Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TDataObject, TBusinessObject>(Expression<Func<TDataObject, bool>> expr)
            where TDataObject : class, ModelKey where TBusinessObject : class
        {
            return base.GetAllQ<TDataObject, TBusinessObject>(expr);
        }

        public new Queryable<TRepositoryProvider, TBusinessObject> GetAllQ<TDataObject, TBusinessObject>() where TDataObject : class, ModelKey where TBusinessObject : class
        {
            return base.GetAllQ<TDataObject, TBusinessObject>();
        }

        public new Queryable<TRepositoryProvider, TPoco> GetAllQ<TPoco>(Expression<Func<TPoco, bool>> expr)
            where TPoco : class, ModelKey
        {
            return base.GetAllQ(expr);
        }

        public new Queryable<TRepositoryProvider, TPoco> GetAllQ<TPoco>() where TPoco : class, ModelKey
        {
            return base.GetAllQ<TPoco>();
        }
    }
}
