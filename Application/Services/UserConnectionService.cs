using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using AutoMapper;
using Domain.Dtos.UserConnectionDtos;

namespace Application.Services;

public class UserConnectionService : GenericCrudService<UserConnection, IUserConnectionRepository>, IUserConnectionService
{

    private IMapper _mapper;
    private IUserConnectionRepository _userConnectionRepository;

    public UserConnectionService(IUserConnectionRepository repository, IMapper mapper)
    : base(repository, mapper)
    {
        _mapper = mapper;
        _userConnectionRepository = repository;
    }

    public async override Task<IEnumerable<OutputDto>> FilteredList<InputDto, OutputDto>(InputDto inputDto)
    {
        var listUserConnectionDto = inputDto as ListUserConnectionDto;

        var filterPredicate = _userConnectionRepository.GetUserConnectionPredicate(listUserConnectionDto.UserId);

        var filterListedEntities = await _userConnectionRepository.List(filterPredicate);

        var filterListedDtos = _mapper.Map<IEnumerable<OutputDto>>(filterListedEntities);

        return filterListedDtos;
    }

    public async Task<RequestedUserConnectionDto> RequestUserConnection(RequestUserConnectionDto requestUserConnectionDto)
    {
        var requestConnection = _mapper.Map<UserConnection>(requestUserConnectionDto);

        requestConnection.Status = false;

        requestConnection.LastViewedRequester = DateTime.Now;

        await _userConnectionRepository.Insert(requestConnection);

        var requestedUserConnection = _mapper.Map<RequestedUserConnectionDto>(requestConnection);

        return requestedUserConnection;
    }

    public async Task<DeletedAllConnectionsFromUserDto> DeleteAllConnectionsFromUser(DeleteAllConnectionsFromUserDto deleteAllConnectionsFromUserDto)
    {
        await _userConnectionRepository.DeleteAllConnectionsFromUser(deleteAllConnectionsFromUserDto);

        return new DeletedAllConnectionsFromUserDto {
            UserId = deleteAllConnectionsFromUserDto.UserId
        };
    }

    public async Task<StatusUserConnectionDto> ReplyToUserConnectionRequest(ReplyUserConnectionDto replyUserConnectionDto)
    {
        if(replyUserConnectionDto.Status == false) {

            var deleteConnection = _mapper.Map<UserConnection>(replyUserConnectionDto);

            var deletedConnection = _userConnectionRepository.Delete(deleteConnection);

            return _mapper.Map<StatusUserConnectionDto>(deletedConnection);

        } else {

            return await Update<ReplyUserConnectionDto, StatusUserConnectionDto>(replyUserConnectionDto);
        }
    }
}
