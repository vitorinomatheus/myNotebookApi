using Domain.Dtos;
using Domain.Dtos.NotebookDtos;
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
    private INotebookService _notebookService;

    public UserService(
        IUserRepository repository, 
        IMapper mapper, 
        IHashPasswords hashPasswords,
        INotebookService notebookService
        )
        : base(repository, mapper)
    {
        _mapper = mapper;
        _repository = repository;
        _hashPasswords = hashPasswords;
        _notebookService = notebookService;
    }

    public async override Task<OutputDto> Insert<InputDto, OutputDto>(InputDto inputDto)
    {
        try
        {
            _repository.BeginTransaction();

            var createUser = _mapper.Map<User>(inputDto);

            var createdUser = await _repository.Insert(createUser);

            await _hashPasswords.HashPassword(createdUser);

            var createNotebookDto = new CreateNotebookDto {
                UserId = createdUser.Id
            };

            await _notebookService.Insert<CreateNotebookDto, CreatedNotebookDto>(createNotebookDto);

            _repository.CommitTransaction();

            var createdUserDto = _mapper.Map<OutputDto>(createdUser);

            return createdUserDto;
        }
        catch (System.Exception)
        {
            _repository.RollbackTransaction();
            throw;
        }
    }
}
