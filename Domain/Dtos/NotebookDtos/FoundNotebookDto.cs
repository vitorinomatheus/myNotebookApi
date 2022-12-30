using AutoMapper;
using Domain.Entities;

namespace Domain.Dtos.NotebookDtos;

[AutoMap(typeof(Notebook), ReverseMap = true)]
public class FoundNotebookDto
{
    public int Id { get; set; }
    
    public int PageCount { get; set; }

    public DateTime LastUpdated { get; set; }

    public int UserId { get; set; }

}
