using Domain.Entities;

namespace Domain.Interfaces.UtilsInterfaces;

public interface IHashPasswords
{
    Task<User> HashPassword(User entity);
}
