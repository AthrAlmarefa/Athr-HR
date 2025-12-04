
namespace Athr.Domain.TaskWork
{
    public interface ITaskWorkRepository
    {
        Task<TaskWork?> GetByIdAsync(TaskWorkId id, CancellationToken cancellationToken = default);
        IQueryable<TaskWork> All();
        Task AddAsync(TaskWork taskWork);
        void Update(TaskWork taskWork);
    }
}
