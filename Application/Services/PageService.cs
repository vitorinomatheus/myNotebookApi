using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using AutoMapper;
using Domain.Dtos.PageDtos;

namespace Application.Services;

public class PageService : GenericCrudService<Page, IPageRepository>, IPageService
{
    private IMapper _mapper;
    private IPageRepository _pageRepository;

    public PageService(IPageRepository repository, IMapper mapper)
    : base(repository, mapper)
    {
        _mapper = mapper;
        _pageRepository = repository;
    }

    public async Task<DeletedAllPagesFromNotebookDto> DeleteAllPagesFromNotebook(DeleteAllPagesFromNotebookDto deleteAllPagesFromNotebookDto)
    {
        var deleteAllPages = _mapper.Map<Page>(deleteAllPagesFromNotebookDto);

        await _pageRepository.DeleteAllPagesFromNotebook(deleteAllPages);

        var deletedAllPagesFromNotebookDto = _mapper.Map<DeletedAllPagesFromNotebookDto>(deleteAllPages);

        return deletedAllPagesFromNotebookDto;
    }
}
