using Infra.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext) : 
        base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetByLogin(User user)
    {
        var getUserLogin = new User{
            Login = user.Login
        };

        var userLoginPredicate = GetFilterPredicate(getUserLogin);

        var foundUser = await _dbContext.Set<User>()
            .Where(userLoginPredicate)
            .FirstOrDefaultAsync();

        return foundUser;
    }

    public async Task<User> Login(User user)
    {
        Expression<Func<User, bool>> expression = default;

        expression = u => u.Login == user.Login && u.Password == user.Password;

        var foundUser = await _dbContext.Set<User>()
            .Where(expression)
            .FirstOrDefaultAsync();

        return foundUser;
    }
}
