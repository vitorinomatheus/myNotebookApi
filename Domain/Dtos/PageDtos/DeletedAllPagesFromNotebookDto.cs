using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.PageDtos;

[AutoMap(typeof(Page), ReverseMap = true)]
public class DeletedAllPagesFromNotebookDto
{
    public int NotebookId { get; set; }
}
