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
}
