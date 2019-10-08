using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OYASAR.Framework.Core.CustomType;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Extensions
{
    public static class QueryableExtension
    {
        public static Queryable<TRepositoryProvider, TEntity> ToQueryable<TRepositoryProvider, TEntity>(this IQueryable<TEntity> value, TRepositoryProvider repositoryProvider)
           where TEntity : class where TRepositoryProvider : class, IRepository
        {
            return Queryable<TRepositoryProvider, TEntity>.CreateQueryable(value, repositoryProvider);
        }

        public static Queryable<TRepositoryProvider, TEntity> Where<TRepositoryProvider, TEntity>(this Queryable<TRepositoryProvider, TEntity> value, Expression<Func<TEntity, bool>> expr)
           where TEntity : class where TRepositoryProvider : class, IRepository
        {
            value = value.Where(expr);
            
            return value;
        }

        public static async Task<IList<TEntity>> ToListAsync<TEntity, TRepositoryProvider>(this Queryable<TRepositoryProvider, TEntity> queryable)
            where TEntity : class where TRepositoryProvider : class, IRepository
        {
            var repository = queryable.RepositoryProvider;

            return await repository.GetListAsync(queryable);
        }

        public static async Task<TEntity> SingleOrDefaultAsync<TEntity, TRepositoryProvider>(this Queryable<TRepositoryProvider, TEntity> queryable)
            where TEntity : class where TRepositoryProvider : class, IRepository
        {
            var repository = queryable.RepositoryProvider;

            return await repository.GetSingleOrDefaultAsync(queryable);
        }

        public static async Task<TEntity> FirstOrDefaultAsync<TEntity, TRepositoryProvider>(this Queryable<TRepositoryProvider, TEntity> queryable)
            where TEntity : class where TRepositoryProvider : class, IRepository
        {
            var repository = queryable.RepositoryProvider;

            return await repository.GetFirstOrDefaultAsync(queryable);
        }
    }
}
