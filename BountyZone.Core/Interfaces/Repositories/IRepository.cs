using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace BountyZone.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);

        T GetByID(int id);

        T Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        void Patch<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression);
    }
}
