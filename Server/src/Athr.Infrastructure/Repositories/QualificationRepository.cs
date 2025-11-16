using Athr.Domain.Qualification;

namespace Athr.Infrastructure.Repositories;

internal sealed class QualificationRepository : Repository<Qualification, QualificationId>, IQualificationRepository
{
    private readonly ApplicationDbContext _dbContext;
    public QualificationRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
