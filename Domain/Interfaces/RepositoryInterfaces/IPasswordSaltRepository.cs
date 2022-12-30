using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces;

public interface IPasswordSaltRepository : IRepository<PasswordSalt>
{
    Task<PasswordSalt> GetByUserId(PasswordSalt entity);
}
