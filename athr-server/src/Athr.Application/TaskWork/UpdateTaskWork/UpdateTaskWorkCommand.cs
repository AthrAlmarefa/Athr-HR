using Athr.Application.Abstractions.Messaging;
namespace Athr.Application.TaskWork.UpdateTaskWork
{
    public sealed record UpdateTaskWorkCommand(
    
        Guid TaskId,
        string Name,
        Guid UserId,
        int PriorityKey,
        DateTime StartDate,
        DateTime EndDate,
        string Description
    ) : ICommand<Guid>;
    
}
