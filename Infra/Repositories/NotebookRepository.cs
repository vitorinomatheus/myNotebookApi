using Infra.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories;

public class NotebookRepository : Repository<Notebook>, INotebookRepository
{
    private readonly ApplicationDbContext _dbContext;

    NotebookRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
