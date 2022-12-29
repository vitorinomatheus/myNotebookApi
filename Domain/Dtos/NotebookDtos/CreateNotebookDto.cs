using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.NotebookDtos;

[AutoMap(typeof(Notebook), ReverseMap = true)]
public class CreateNotebookDto
{
    public int UserId { get; set; }
}
