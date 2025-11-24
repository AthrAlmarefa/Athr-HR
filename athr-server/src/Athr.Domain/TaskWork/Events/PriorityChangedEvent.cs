using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.TaskWork.Events
{
    public sealed class PriorityChangedEvent : IDomainEvent
    {
        public TaskWork TaskWork { get; }
        public Priority OldPriority { get; }
        public Priority NewPriority { get; }
        public DateTime OccurredOn { get; }

        public PriorityChangedEvent(TaskWork taskWork, Priority oldPriority, Priority newPriority)
        {
            TaskWork = taskWork;
            OldPriority = oldPriority;
            NewPriority = newPriority;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
