using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos;

[AutoMap(typeof(User), ReverseMap = true)]
public class LoginUserDto
{
    public string Login { get; set; }

    public string Password { get; set; }
}
