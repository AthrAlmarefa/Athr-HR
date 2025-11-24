using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.TaskWork.Events
{
    public sealed class TaskWorkUpdatedEvent: IDomainEvent
    {
        public TaskWork TaskWork { get; }

        public TaskWorkUpdatedEvent(TaskWork taskWork)
        {
            TaskWork = taskWork;
        }
    }
}
