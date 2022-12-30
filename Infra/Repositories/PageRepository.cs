using Infra.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories;

public class PageRepository : Repository<Page>, IPageRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PageRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteAllPagesFromNotebook(Page page)
    {
        var predicate = GetFilterPredicate(page);

        var pagesToDelete = _dbContext.Set<Page>().Where(predicate).ToList();

        _dbContext.RemoveRange(pagesToDelete);

        await _dbContext.SaveChangesAsync();
    }

}
