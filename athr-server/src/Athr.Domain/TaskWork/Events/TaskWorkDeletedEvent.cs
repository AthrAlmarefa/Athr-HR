using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.TaskWork.Events
{
    public sealed class TaskWorkDeletedEvent: IDomainEvent
    {
        public TaskWork TaskWork { get; }

        public TaskWorkDeletedEvent(TaskWork taskWork)
        {
            TaskWork = taskWork;
        }
    }
}
