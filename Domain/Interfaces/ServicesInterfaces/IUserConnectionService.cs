using Domain.Dtos;
using Domain.Interfaces;
using Domain.Dtos.UserConnectionDtos;

namespace Domain.Interfaces.Services;

public interface IUserConnectionService: IGenericCrudService
{
    Task<DeletedAllConnectionsFromUserDto> DeleteAllConnectionsFromUser(DeleteAllConnectionsFromUserDto deleteAllConnectionsFromUserDto);
    Task<RequestedUserConnectionDto> RequestUserConnection(RequestUserConnectionDto requestUserConnectionDto);
}
