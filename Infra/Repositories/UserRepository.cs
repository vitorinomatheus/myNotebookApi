using Infra.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext) : 
        base(dbContext)
    {
        _dbContext = dbContext;
    }
}
