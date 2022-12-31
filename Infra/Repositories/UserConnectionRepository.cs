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

        var queriedFields = typeof(UserConnection).GetProperties();

        foreach(var prop in queriedFields)
        {
            if(prop.Name == nameof(UserConnection.ConnectionAddressee) || prop.Name ==  nameof(UserConnection.ConnectionRequester))
            {
                var parameter = Expression.Parameter(typeof(UserConnection));
                var left = Expression.Property(parameter, prop.Name);
                Expression<Func<object>> right = () => userId;
                var convertedRight = Expression.Convert(right.Body, userId.GetType());
                var body = Expression.Equal(left, convertedRight);
                var predicate = Expression.Lambda<Func<UserConnection, bool>>(body, new ParameterExpression[] { parameter });

                expression = predicate;
            }
        }

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
