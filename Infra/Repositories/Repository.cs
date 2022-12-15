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

    public async void Insert(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async void Update(T entity)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();

        // Study the differences between the two methods and decide which one to use here
        // _dbContext.Entry(entity).State = EntityState.Modified;
        // _dbContext.SaveChanges();
    }

    public async void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}
