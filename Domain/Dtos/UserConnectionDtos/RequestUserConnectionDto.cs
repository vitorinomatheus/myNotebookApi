using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.UserConnectionDtos;

[AutoMap(typeof(UserConnection), ReverseMap = true)]
public class RequestUserConnectionDto
{
    public int ConnectionRequester { get; set; }

    public int ConnectionAddressee { get; set; }
}
