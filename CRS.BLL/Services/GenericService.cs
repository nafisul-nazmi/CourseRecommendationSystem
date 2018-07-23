using CRS.BLL.Interfaces;
using CRS.DAL.Interfaces;
using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CRS.BLL.Services
{
    public abstract class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        protected IGenericRepository<T> repository;

        protected GenericService(IGenericRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }

        public virtual T Get(int id)
        {
            return repository.Get(id);
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return repository.FindBy(expression);
        }

        public virtual T Add(T entity)
        {
            return repository.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return repository.Delete(entity);
        }

        public virtual void Edit(T entity)
        {
            repository.Edit(entity);
        }
        
    }
}
