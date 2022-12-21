using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces.UtilsInterfaces;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Services;

public class UserService : GenericCrudService<User, IUserRepository>, IUserService
{
    private IMapper _mapper;
    private IUserRepository _repository;
    private IHashPasswords _hashPasswords;

    public UserService(IUserRepository repository, IMapper mapper, IHashPasswords hashPasswords)
        : base(repository, mapper)
    {
        _mapper = mapper;
        _repository = repository;
        _hashPasswords = hashPasswords;
    }

    public async override Task<OutputDto> Insert<InputDto, OutputDto>(InputDto inputDto)
    {
        var createUser = _mapper.Map<User>(inputDto);

        var createdUser = await _repository.Insert(createUser);

        await _hashPasswords.HashPassword(createdUser);

        /*
        Criar o caderno;

        Chamar a service de criar caderno;
        */

        var createdUserDto = _mapper.Map<OutputDto>(createdUser);

        return createdUserDto;
    }

}
