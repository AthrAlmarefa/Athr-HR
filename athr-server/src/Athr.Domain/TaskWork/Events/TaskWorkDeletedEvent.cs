using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.TaskWork.Events
{
    public sealed class TaskWorkDeletedEvent: IDomainEvent
    {
        public Guid TaskWorkId { get; }

        public Guid UserId { get; }
        public TaskWorkDeletedEvent(Guid taskWorkId,Guid userId)
        {
            TaskWorkId = taskWorkId;
            UserId = userId;
        }
    }
}
