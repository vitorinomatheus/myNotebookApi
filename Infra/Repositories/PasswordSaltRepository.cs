using Domain.Entities;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class PasswordSaltRepository : Repository<PasswordSalt>
{
    private readonly ApplicationDbContext _dbContext;

    public PasswordSaltRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PasswordSalt> GetByUserId(PasswordSalt entity)
    {
        return await _dbContext.Set<PasswordSalt>()
            .Where(x => x.UserId == entity.UserId)
            .FirstOrDefaultAsync();
    }
}
