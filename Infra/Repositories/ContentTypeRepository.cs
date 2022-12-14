using Infra.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories;

public class ContentTypeRepository : Repository<ContentType>, IContentTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    ContentTypeRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

}
