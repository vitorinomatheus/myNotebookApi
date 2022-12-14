using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Services;

public class PageService : GenericCrudService<Page, IPageRepository>, IPageService
{
    public PageService(IPageRepository repository, IMapper mapper)
    : base(repository, mapper)
    {
    }
}
