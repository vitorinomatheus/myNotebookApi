using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Services;

public class UserService : GenericCrudService<User, IUserRepository>, IUserService
{
    public UserService(IUserRepository repository, IMapper mapper)
        : base(repository, mapper)
    {
    }

}
