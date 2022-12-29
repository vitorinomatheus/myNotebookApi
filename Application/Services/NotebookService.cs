using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using Domain.Dtos.PageDtos;
using AutoMapper;

namespace Application.Services;

public class NotebookService: GenericCrudService<Notebook, INotebookRepository>, INotebookService
{   private IMapper _mapper;
    private IPageService _pageService;
    private INotebookRepository _repository;

    public NotebookService(INotebookRepository repository, IMapper mapper, IPageService pageService)
    : base(repository, mapper)
    {
        _pageService = pageService;
        _mapper = mapper;
        _repository = repository;
    }
  
    public async override Task<OutputDto> Insert<InputDto, OutputDto>(InputDto inputDto)
    {
        var createNotebook = _mapper.Map<Notebook>(inputDto);

        createNotebook.LastUpdated = DateTime.Now;
        createNotebook.PageCount = 1;

        var createdNotebook = await _repository.Insert(createNotebook);

        var createFirstPageDto = new CreatePageDto {
            NotebookId = createdNotebook.Id,
            ContentTypeId = 3            
        };

        await _pageService.Insert<CreatePageDto, CreatedPageDto>(createFirstPageDto);

        var createdNotebookDto = _mapper.Map<OutputDto>(createdNotebook);

        return createdNotebookDto;
    }
}
