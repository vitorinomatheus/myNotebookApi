namespace Domain.Interfaces.Services;
using Domain.Dtos.PageDtos;

public interface IPageService : IGenericCrudService
{
    Task<DeletedAllPagesFromNotebookDto> DeleteAllPagesFromNotebook(DeleteAllPagesFromNotebookDto deleteAllPagesFromNotebookDto);
}
