using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    Task<T> GetById(T entity);

    Task<IEnumerable<T>> List(T entity);

    Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);

    Task<T> Insert(T entity);

    Task<T> Delete(T entity);

    Task<T> Update(T entity);

    Expression<Func<T, bool>> GetFilterPredicate(T entity);

}
