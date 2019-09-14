using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OYASAR.Framework.Core.Interface;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OYASAR.Framework.EFProvider.NetCore.PostgreSQL
{
    public class EFRepository<TK> : IEFPostgreSQLRepository<TK>
    {
        private readonly DbContext _dbContext;

        public EFRepository(TK dbContext)
        {
            this._dbContext = dbContext as DbContext;
        }

        public T Add<T>(T entity) where T : class
        {
            var dbSet = _dbContext.Set<T>();
            dbSet.Add(entity);
            return entity;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            var dbSet = _dbContext.Set<T>();
            return dbSet.AsQueryable();
        }

        public T GetByKey<T>(object key) where T : class
        {
            var dbSet = _dbContext.Set<T>();
            return dbSet.Find(key);
        }

        public T DeleteByKey<T>(object key) where T : class
        {
            var dbSet = _dbContext.Set<T>();
            var entity = GetByKey<T>(key);
            dbSet.Remove(entity);
            return entity;
        }

        public void Edit<T>(T entity) where T : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void LazyLoad<T, TK>(T entity, Expression<Func<T, IEnumerable<TK>>> expr) where T : class where TK : class
        {
            _dbContext.Entry(entity).Collection(expr).Load();
        }

        public void LazyLoad<T, TK>(T entity) where T : class where TK : class
        {
            _dbContext.Entry(entity).Reference(typeof(TK).Name).Load();
        }

        public void LazyLoad<T, TK>(T entity, Expression<Func<T, ICollection<TK>>> expr) where T : class where TK : class
        {
            throw new Exception("EntityFramework.Core is not supported Expr!");
        }

        public IQueryable<T> SqlQuery<T>(string str, params object[] obj) where T : class
        {
            throw new Exception("EntityFramework.Core is not supported SqlQuery!");
        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> expr) where T : class
        {
            var dbSet = _dbContext.Set<T>().Where(expr);
            return dbSet.AsQueryable();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<IList<T>> GetAllAsync<T>() where T : class
        {
            var dbSet = _dbContext.Set<T>();
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByKeyAsync<T>(object key) where T : class
        {
            var dbSet = _dbContext.Set<T>();
            return await dbSet.FindAsync(key);
        }

        public Task<IList<T>> SqlQueryAsync<T>(string str, params object[] obj) where T : class
        {
            throw new Exception("EntityFramework.Core is not supported SqlQuery!");
        }

        public async Task<IList<T>> GetAllAsync<T>(Expression<Func<T, bool>> expr) where T : class
        {
            var dbSet = _dbContext.Set<T>().Where(expr);
            return await dbSet.ToListAsync();
        }

        public Task LazyLoadAsync<T, TK>(T entity, Expression<Func<T, ICollection<TK>>> expr)
            where T : class
            where TK : class
        {           
            throw new Exception("EntityFramework is not supported Expr!");
        }

        public async Task LazyLoadAsync<T, TK>(T entity, Expression<Func<T, IEnumerable<TK>>> expr)
            where T : class
            where TK : class
        {
            await _dbContext.Entry(entity).Collection(expr).LoadAsync();
        }

        public async Task LazyLoadAsync<T, TK>(T entity)
            where T : class
            where TK : class
        {
            await _dbContext.Entry(entity).Reference(typeof(TK).Name).LoadAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetListAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return await queryable.ToListAsync();
        }

        public async Task<TEntity> GetSingleOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return await queryable.SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync<TEntity>(IQueryable<TEntity> queryable) where TEntity : class
        {
            return await queryable.FirstOrDefaultAsync();
        }
    }

}