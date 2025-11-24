using Athr.Domain.BuildingBlocks;
namespace Athr.Domain.TaskWork.Events
{
    public sealed class TaskWorkCreatedEvent :IDomainEvent
    {
        public TaskWork TaskWork { get; }

        public TaskWorkCreatedEvent(TaskWork taskWork)
        {
            TaskWork = taskWork;
        }
    }
}
