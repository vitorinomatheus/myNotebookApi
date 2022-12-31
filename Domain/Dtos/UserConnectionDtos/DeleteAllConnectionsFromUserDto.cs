using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.UserConnectionDtos;

[AutoMap(typeof(UserConnection), ReverseMap = true)]
public class DeleteAllConnectionsFromUserDto
{
    public int UserId { get; set; }
}
