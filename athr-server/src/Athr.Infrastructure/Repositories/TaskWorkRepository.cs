using Athr.Domain.TaskWork;
namespace Athr.Infrastructure.Repositories
{
    internal sealed class TaskWorkRepository : Repository<TaskWork, TaskWorkId>, ITaskWorkRepository
    {
        public TaskWorkRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
