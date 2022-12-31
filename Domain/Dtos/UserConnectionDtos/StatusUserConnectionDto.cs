using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.UserConnectionDtos;

[AutoMap(typeof(UserConnection), ReverseMap = true)]
public class StatusUserConnectionDto
{
    public int Id { get; set; }

    public bool Status { get; set; }
}
