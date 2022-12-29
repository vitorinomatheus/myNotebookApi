using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.PageDtos;

[AutoMap(typeof(Page), ReverseMap = true)]
public class CreatedPageDto
{
    public int Id { get; set; }
}
