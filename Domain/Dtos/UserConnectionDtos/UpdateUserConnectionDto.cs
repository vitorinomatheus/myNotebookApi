using System.Text.Json.Serialization;
using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.UserConnectionDtos;

[AutoMap(typeof(UserConnection), ReverseMap = true)]
public class UpdateUserConnectionDto
{
    [JsonIgnore]
    public int Id { get; set; }

    public bool Status { get; set; }

    public DateTime LastViewedRequester { get; set; }

    public DateTime LastViewedAddressee { get; set; }
}
