using Infra.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories;

public class PageRepository : Repository<Page>, IPageRepository
{
    private readonly ApplicationDbContext _dbContext;

    PageRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
