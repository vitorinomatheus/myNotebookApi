using Domain.Entities;
using Domain.Dtos.UserConnectionDtos;
using System.Linq.Expressions;

namespace Domain.Interfaces;

public interface IUserConnectionRepository : IRepository<UserConnection>
{
    Task DeleteAllConnectionsFromUser(DeleteAllConnectionsFromUserDto deleteAllConnectionsFromUserDto);
    Expression<Func<UserConnection, bool>> GetUserConnectionPredicate(int userId);
}
