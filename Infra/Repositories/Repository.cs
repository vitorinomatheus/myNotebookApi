using Domain.Interfaces;
using Domain.Entities;
using Infra.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class Repository<T> : IRepository<T> 
    where T : EntityBase
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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
        return await _dbContext.Set<T>()
                .Where(predicate)
                .ToListAsync();
    }

    public async Task<T> Insert(T entity)
    {
        var insertedEntity = await _dbContext.Set<T>().AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return insertedEntity.Entity;
    }

    public async Task<T> Update(T entity)
    {
        var updatedEntity = _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();

        return updatedEntity.Entity;

        // Study the differences between the two methods and decide which one to use here
        // _dbContext.Entry(entity).State = EntityState.Modified;
        // _dbContext.SaveChanges();
    }

    public async Task<T> Delete(T entity)
    {
        var deletedEntity = _dbContext.Set<T>().Remove(entity);

        await _dbContext.SaveChangesAsync();

        return deletedEntity.Entity;
    }
}
