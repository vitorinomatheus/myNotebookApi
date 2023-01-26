using Domain.Dtos;
using Domain.Interfaces;

namespace Domain.Interfaces.Services;

public interface IUserService : IGenericCrudService
{
    Task<LoggedinUserDto> LoginUser(LoginUserDto loginUserDto);
    
}
