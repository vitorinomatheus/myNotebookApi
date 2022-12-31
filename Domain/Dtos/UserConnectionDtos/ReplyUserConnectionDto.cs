using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.UserConnectionDtos;

[AutoMap(typeof(UserConnection), ReverseMap = true)]
public class ReplyUserConnectionDto
{
    public int Id { get; set; }

    public bool Status { get; set; }
}
