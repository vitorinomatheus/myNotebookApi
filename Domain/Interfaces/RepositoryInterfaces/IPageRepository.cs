using Domain.Entities;

namespace Domain.Interfaces;

public interface IPageRepository : IRepository<Page>
{
    Task DeleteAllPagesFromNotebook(Page page);
}
