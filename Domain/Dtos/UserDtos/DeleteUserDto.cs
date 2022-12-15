using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos;

[AutoMap(typeof(User), ReverseMap = true)]
public class DeleteUserDto
{
    public int Id { get; set; }
}
