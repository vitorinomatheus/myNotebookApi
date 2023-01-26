using Domain.Dtos;
using Domain.Dtos.NotebookDtos;
using Domain.Dtos.PageDtos;
using Domain.Dtos.UserConnectionDtos;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces.RepositoryInterfaces;
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
    private IPageService _pageService;
    private IUserConnectionService _userConnectionService;
    private IPasswordSaltRepository _passwordSaltRepository;

    public UserService(
        IUserRepository repository, 
        IMapper mapper, 
        IHashPasswords hashPasswords,
        INotebookService notebookService,
        IPageService pageService,
        IUserConnectionService userConnectionService,
        IPasswordSaltRepository passwordSaltRepository
        )
        : base(repository, mapper)
    {
        _mapper = mapper;
        _repository = repository;
        _hashPasswords = hashPasswords;
        _notebookService = notebookService;
        _pageService = pageService;
        _userConnectionService =  userConnectionService;
        _passwordSaltRepository = passwordSaltRepository;
    }

    public async override Task<OutputDto> Insert<InputDto, OutputDto>(InputDto inputDto)
    {
        try
        {
            _repository.BeginTransaction();

            var createUser = _mapper.Map<User>(inputDto);

            var repeatedLoginUser = await _repository.GetByLogin(createUser);

            if(repeatedLoginUser != null)
            {
                throw new System.Exception();
            }

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

    public async override Task<OutputDto> Update<InputDto, OutputDto>(InputDto inputDto)
    {
        var updateUser = _mapper.Map<User>(inputDto);
        
        if(updateUser.Password != null)
        {
            await _hashPasswords.HashPassword(updateUser);
            return _mapper.Map<OutputDto>(updateUser);
        }
        else 
        {
            return await base.Update<InputDto, OutputDto>(inputDto);
        }
    }

    public async override Task<OutputDto> Delete<InputDto, OutputDto>(InputDto inputDto)
    {
        var deleteUserDto = inputDto as DeleteUserDto;

        var getNotebookByUserId = new GetNotebookByUserIdDto {
            UserId = deleteUserDto.Id
        };

        var notebookUser = await _notebookService.FilteredList<GetNotebookByUserIdDto, FoundNotebookByUserIdDto>(getNotebookByUserId);

        var deleteAllPagesFromNotebookDto = new DeleteAllPagesFromNotebookDto {
            NotebookId = notebookUser.First().Id
        };

        var deleteAllConnectionsFromUserDto = new DeleteAllConnectionsFromUserDto {
            UserId = deleteUserDto.Id
        };

        var deleteNotebook = new DeleteNotebookDto {
            Id = notebookUser.First().Id
        };

        var deleteSalt = new PasswordSalt {
            UserId = deleteUserDto.Id
        };

        try
        {
            _repository.BeginTransaction();

            await _pageService.DeleteAllPagesFromNotebook(deleteAllPagesFromNotebookDto);
            
            await _userConnectionService.DeleteAllConnectionsFromUser(deleteAllConnectionsFromUserDto);

            await _passwordSaltRepository.Delete(deleteSalt);

            await _notebookService.Delete<DeleteNotebookDto, DeletedNotebookDto>(deleteNotebook);
            
            var deleteUser = _mapper.Map<User>(inputDto);

            var deletedUser = await _repository.Delete(deleteUser);

            var deletedDto = _mapper.Map<OutputDto>(deletedUser);

            _repository.CommitTransaction();

            return deletedDto;
        }
        catch (System.Exception)
        {
            _repository.RollbackTransaction();
            throw;
        }
    }

    public async Task<LoggedinUserDto> LoginUser(LoginUserDto loginUserDto)
    {
        var verifyUserLogin = _mapper.Map<User>(loginUserDto);

        var foundUser = await _repository.GetByLogin(verifyUserLogin);

        verifyUserLogin.Id = foundUser.Id;

        var verifiedPassowrd = await _hashPasswords.VerifyPassword(verifyUserLogin);

        if(verifiedPassowrd == true && foundUser != null)
        {
            var loggedInUserDto = _mapper.Map<LoggedinUserDto>(foundUser);
            return loggedInUserDto;
        }
        else 
        {
            throw new System.Exception();
        }
    }
}
