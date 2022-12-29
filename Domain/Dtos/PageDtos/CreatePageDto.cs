using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.PageDtos;

[AutoMap(typeof(Page), ReverseMap = true)]
public class CreatePageDto
{
    public int NotebookId { get; set; }

    public int ContentTypeId { get; set; }
}
