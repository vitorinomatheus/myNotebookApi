using Infra.Data;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq.Expressions;
using Domain.Dtos.UserConnectionDtos;

namespace Infra.Repositories;

public class UserConnectionRepository : Repository<UserConnection>, IUserConnectionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserConnectionRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Expression<Func<UserConnection, bool>> GetUserConnectionPredicate(int userId)
    {
        Expression<Func<UserConnection, bool>> expression = default;

        expression = s => s.ConnectionAddressee == userId || s.ConnectionRequester == userId;

        return expression;        
    }

    public async Task DeleteAllConnectionsFromUser(DeleteAllConnectionsFromUserDto deleteAllConnectionsFromUserDto)
    {
        var predicate = GetUserConnectionPredicate(deleteAllConnectionsFromUserDto.UserId);

        var connectionsToDelete = _dbContext.Set<UserConnection>()
            .Where(predicate)
            .ToList();

        _dbContext.RemoveRange(connectionsToDelete);

        await _dbContext.SaveChangesAsync(); 
    }
}
