using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos;

[AutoMap(typeof(User), ReverseMap = true)]

public class UpdatedUserDto
{
    public int Id { get; set; }
}
