using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Services;

public class UserConnectionService : GenericCrudService<UserConnection, IUserConnectionRepository>, IUserConnectionService
{
    public UserConnectionService(IUserConnectionRepository repository, IMapper mapper)
    : base(repository, mapper)
    {
    }
}
