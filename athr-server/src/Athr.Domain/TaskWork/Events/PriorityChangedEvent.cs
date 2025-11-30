using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.TaskWork.Events
{
    public sealed class PriorityChangedEvent : IDomainEvent
    {
        public Guid TaskWork { get; }
        public Priority OldPriority { get; }
        public Priority NewPriority { get; }
      

        public PriorityChangedEvent(Guid taskWork, Priority oldPriority, Priority newPriority)
        {
            TaskWork = taskWork;
            OldPriority = oldPriority;
            NewPriority = newPriority;
       
        }
    }
}
