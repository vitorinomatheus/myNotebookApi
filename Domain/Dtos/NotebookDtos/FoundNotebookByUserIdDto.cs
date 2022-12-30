using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.NotebookDtos;

[AutoMap(typeof(Notebook), ReverseMap = true)]
public class FoundNotebookByUserIdDto
{
    public int Id { get; set; }
}
