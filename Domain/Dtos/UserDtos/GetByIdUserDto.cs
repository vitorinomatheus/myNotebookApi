using System.Reflection.Metadata;
using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos;

[AutoMap(typeof(User), ReverseMap = true)]

public class GetByIdUserDto
{
    public int Id { get; set; }
}
