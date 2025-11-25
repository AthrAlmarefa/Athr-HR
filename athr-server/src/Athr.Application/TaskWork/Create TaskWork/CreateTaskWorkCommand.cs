using Athr.Application.Abstractions.Messaging;
namespace Athr.Application.TaskWork.Create_TaskWork
{
    public sealed record CreateTaskWorkCommand: ICommand<Guid>
    {
        public string Name { get; init; }
        public Guid UserId { get; init; }
        public int PriorityKey { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public string Description { get; init; }
    }
}

