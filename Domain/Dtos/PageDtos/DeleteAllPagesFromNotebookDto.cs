using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.PageDtos;

[AutoMap(typeof(Page), ReverseMap = true)]
public class DeleteAllPagesFromNotebookDto
{
    public int NotebookId { get; set; }
}
