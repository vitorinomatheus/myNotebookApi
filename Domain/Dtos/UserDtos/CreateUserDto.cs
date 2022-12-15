using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos;

[AutoMap(typeof(User), ReverseMap = true)]

public class CreateUserDto
{
    public string Name { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }
}
