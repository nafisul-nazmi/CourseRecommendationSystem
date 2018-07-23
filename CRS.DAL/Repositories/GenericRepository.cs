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

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable<T>();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).AsEnumerable<T>();
        }

        public virtual T Add(T entity)
        {
            var savedEntity = dbSet.Add(entity);
            dbContext.SaveChanges();
            return savedEntity;
        }

        public virtual T Delete(T entity)
        {
            var deletedEntity = dbSet.Remove(entity);
            dbContext.SaveChanges();
            return deletedEntity;
        }

        public virtual void Edit(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
   
    }
}
