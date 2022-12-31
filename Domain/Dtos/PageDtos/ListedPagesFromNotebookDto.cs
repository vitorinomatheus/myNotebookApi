using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.PageDtos;

[AutoMap(typeof(Page), ReverseMap = true)]
public class ListedPagesFromNotebookDto
{
    public int Id { get; set; }

    public int ContentTypeId { get; set; }

    public string ContentBody { get; set; }
}
