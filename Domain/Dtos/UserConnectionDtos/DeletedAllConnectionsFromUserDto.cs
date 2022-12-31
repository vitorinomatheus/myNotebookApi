using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.UserConnectionDtos;

[AutoMap(typeof(UserConnection), ReverseMap = true)]
public class DeletedAllConnectionsFromUserDto
{
    public int UserId { get; set; }
}
