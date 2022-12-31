using Domain.Interfaces;
using Domain.Entities;
using Infra.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Repositories;

public class Repository<T> : IRepository<T> 
    where T : EntityBase
{
    private readonly ApplicationDbContext _dbContext;

    private IDbContextTransaction _transaction;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async void BeginTransaction() 
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async void CommitTransaction()
    {
        await _transaction.CommitAsync();
        await _transaction.DisposeAsync();
    }

    public async void RollbackTransaction()
    {
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
    }

    public async virtual Task<T> GetById(T entity)
    {
        return await _dbContext.Set<T>().FindAsync(entity.Id);
    }

    public async virtual Task<IEnumerable<T>> List(T entity)
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async virtual Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate)
    {
        var listedEntities = await _dbContext.Set<T>()
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return listedEntities;
    }

    public async virtual Task<T> Insert(T entity)
    {
        var insertedEntity = await _dbContext.Set<T>().AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return insertedEntity.Entity;
    }

    public async virtual Task<T> Update(T entity)
    {
        var foundEntity = await _dbContext.Set<T>().FindAsync(entity.Id);

        var props = entity.GetType().GetProperties();

        foreach(var prop in props)
        {
            var propValue = prop.GetValue(entity);
            if((propValue is not int && propValue != null) 
            || (propValue is int && (int)propValue != 0))
            {
                foundEntity.GetType()
                    .GetProperty(prop.Name)
                    .SetValue(foundEntity, prop.GetValue(entity));
            }
        }

        _dbContext.Entry(foundEntity).CurrentValues.SetValues(foundEntity);
        var updatedEntity = _dbContext.Entry(foundEntity).Entity;
        await _dbContext.SaveChangesAsync();

        return updatedEntity;
    }

    public async virtual Task<T> Delete(T entity)
    {
        var deletedEntity = _dbContext.Set<T>().Remove(entity);

        await _dbContext.SaveChangesAsync();

        return deletedEntity.Entity;
    }

    public virtual Expression<Func<T, bool>> GetFilterPredicate(T entity)
    {
        var props = entity.GetType().GetProperties();

        Expression<Func<T, bool>> expression = default;

        foreach(var prop in props)
        {
            var propertyName = prop.Name;

            var propertyValue = entity.GetType()
                .GetProperty(propertyName)
                .GetValue(entity, null);
                

            if(propertyValue == null)
            {
                continue;
            }
            // TODO: Temporário, rever (por que envia valor 0 no ID?)
            else if ((propertyName == nameof(entity.Id)))
            {
                continue;
            }

            var parameter = Expression.Parameter(typeof(T));
            var left = Expression.Property(parameter, propertyName);
            Expression<Func<object>> right = () => propertyValue;
            var convertedRight = Expression.Convert(right.Body, propertyValue.GetType());
            var body = Expression.Equal(left, convertedRight);
            var predicate = Expression.Lambda<Func<T, bool>>(body, new ParameterExpression[] { parameter });

            expression = predicate;
        }

        return expression;
    }
}
