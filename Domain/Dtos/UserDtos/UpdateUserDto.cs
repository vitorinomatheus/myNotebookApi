using System.Text.Json.Serialization;
using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos;

[AutoMap(typeof(User), ReverseMap = true)]

public class UpdateUserDto
{
    [JsonIgnore]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}
