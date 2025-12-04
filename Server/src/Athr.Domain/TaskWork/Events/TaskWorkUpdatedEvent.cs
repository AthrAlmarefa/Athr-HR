using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.TaskWork.Events
{
    public sealed class TaskWorkUpdatedEvent : IDomainEvent
    {
        public Guid TaskWorkId { get; }
        public Guid UserId { get; }
        public TaskWorkUpdatedEvent(Guid taskWorkId, Guid userId)
        {
            TaskWorkId = taskWorkId;
            UserId = userId;
        }
    }
}