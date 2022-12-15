using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos;

[AutoMap(typeof(User), ReverseMap = true)]
public class FoundUserDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }

}
