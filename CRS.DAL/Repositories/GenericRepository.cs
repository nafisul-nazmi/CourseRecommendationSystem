using CRS.DAL.Interfaces;
using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CRS.DAL.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected DbContext dbContext;
        protected IDbSet<T> dbSet;

        protected GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).AsEnumerable<T>();
        }

        public T Add(T entity)
        {
            var savedEntity = dbSet.Add(entity);
            dbContext.SaveChanges();
            return savedEntity;
        }

        public T Delete(T entity)
        {
            var deletedEntity = dbSet.Remove(entity);
            dbContext.SaveChanges();
            return deletedEntity;
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }
   
    }
}
