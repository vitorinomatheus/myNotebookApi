using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Services;

public class NotebookService: GenericCrudService<Notebook, INotebookRepository>, INotebookService
{
    public NotebookService(INotebookRepository repository, IMapper mapper)
    : base(repository, mapper)
    {
    }
}
