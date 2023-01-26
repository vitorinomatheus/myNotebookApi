using Domain.Entities;

namespace Domain.Interfaces.UtilsInterfaces;

public interface IHashPasswords
{
    Task<User> HashPassword(User entity);
    Task<Boolean> VerifyPassword(User entity);
}
