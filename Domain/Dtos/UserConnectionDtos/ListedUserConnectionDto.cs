using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.UserConnectionDtos;

[AutoMap(typeof(UserConnection), ReverseMap = true)]
public class ListedUserConnectionDto
{
    public int Id { get; set; }
    
    public int ConnectionRequester { get; set; }

    public int ConnectionAddressee { get; set; }

    public int Status { get; set; }

    public DateTime LastViewedRequester { get; set; }

    public DateTime LastViewedAddressee { get; set; }

}
