using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    Task<T> GetById(int id);

    Task<IEnumerable<T>> List();

    Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);

    void Insert(T entity);

    void Delete(T entity);

    void Update(T entity);

}
