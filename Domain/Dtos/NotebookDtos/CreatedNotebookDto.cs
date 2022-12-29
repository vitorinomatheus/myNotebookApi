using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.NotebookDtos;

[AutoMap(typeof(Notebook), ReverseMap = true)]
public class CreatedNotebookDto
{
    public int Id { get; set; }
}
