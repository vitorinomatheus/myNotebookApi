using Domain.Entities;
using Infra.Data;

namespace Infra.Repositories;

public class PasswordSaltRepository : Repository<PasswordSalt>
{
    private readonly ApplicationDbContext _dbContext;

    public PasswordSaltRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
