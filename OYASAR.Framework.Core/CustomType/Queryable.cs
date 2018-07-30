using OYASAR.Framework.Core.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OYASAR.Framework.Core.CustomType
{
    public sealed class Queryable<TRepositoryProvider, TEntity> : IQueryable<TEntity> where TRepositoryProvider : class, IRepository
    {
        public Expression Expression { get; set; }

        public Type ElementType { get; set; }

        public IQueryProvider Provider => throw new NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        internal readonly TRepositoryProvider RepositoryProvider;
        
        internal Queryable(IQueryable queryable, TRepositoryProvider repositoryProvider)
           : base()
        {
            this.RepositoryProvider = repositoryProvider;
            this.Expression = queryable.Expression;
            this.ElementType = queryable.ElementType;
        }

        public static Queryable<TRepositoryProvider, TEntity> CreateQueryable(IQueryable<TEntity> value, TRepositoryProvider repositoryProvider)
        {
            return new Queryable<TRepositoryProvider, TEntity>(value, repositoryProvider);
        }
    }
}
