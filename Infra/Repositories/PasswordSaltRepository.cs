using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class PasswordSaltRepository : Repository<PasswordSalt>, IPasswordSaltRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PasswordSaltRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<PasswordSalt> Delete(PasswordSalt entity)
    {
        var foundEntity = await GetByUserId(entity);

        return await base.Delete(foundEntity);
    }

    public override async Task<PasswordSalt> Insert(PasswordSalt entity)
    {
        var foundEntity = await GetByUserId(entity);

        if(foundEntity != null)
        {
            await Delete(foundEntity);
        }

        var insertedEntity = await _dbContext.Set<PasswordSalt>().AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return insertedEntity.Entity;
    }

    public async Task<PasswordSalt> GetByUserId(PasswordSalt entity)
    {
        return await _dbContext.Set<PasswordSalt>()
            .Where(x => x.UserId == entity.UserId)
            .FirstOrDefaultAsync();
    }
}
