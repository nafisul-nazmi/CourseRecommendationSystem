using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CRS.DAL.Interfaces
{
    interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> expression);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
    }
}
