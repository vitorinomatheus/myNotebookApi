using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Services;

public class ContentTypeService : GenericCrudService<ContentType, IContentTypeRepository>, IContentTypeService
{

    public ContentTypeService(IContentTypeRepository repository, IMapper mapper)
    : base(repository, mapper)
    {
    }
}
