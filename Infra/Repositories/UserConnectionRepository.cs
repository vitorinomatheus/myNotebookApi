using Infra.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories;

public class UserConnectionRepository : Repository<UserConnection>, IUserConnectionRepository
{
    private readonly ApplicationDbContext _dbContext;

    UserConnectionRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
