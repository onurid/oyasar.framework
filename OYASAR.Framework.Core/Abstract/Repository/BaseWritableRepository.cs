using OYASAR.Framework.Core.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OYASAR.Framework.Core.Abstract
{
    public abstract class BaseWritableRepository<TRepositoryProvider, ModelKey> : BaseCommonRepository<TRepositoryProvider, ModelKey>, IBaseWritableRepository<ModelKey>  where TRepositoryProvider : class, IRepository where ModelKey : class
    {
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

        public new async Task SaveAsync()
        {
            await base.SaveAsync();
        }

        public new async Task<IList<TEntity>> SqlQueryAsync<TEntity>(string str, params object[] obj) where TEntity : class, ModelKey
        {
            return await base.SqlQueryAsync<TEntity>(str, obj);
        }
    }
}
