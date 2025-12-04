using Athr.Domain.BuildingBlocks;
namespace Athr.Domain.TaskWork.Events
{
    public sealed class TaskWorkCreatedEvent : IDomainEvent
    {
        public Guid TaskWorkId { get; }
        public string Name { get; }
        public Guid UserId { get; }
        public TaskWorkCreatedEvent(Guid taskWorkId, string name, Guid userId)
        {
            TaskWorkId = taskWorkId;
            Name = name;
            UserId = userId;
        }
    }
}