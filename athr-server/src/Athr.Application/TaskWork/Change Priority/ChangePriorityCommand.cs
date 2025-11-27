using MediatR;

namespace Athr.Application.TaskWork.Change_Priorty
{
    public sealed record ChangeTaskPriorityCommand(Guid TaskWorkId, int PriorityKey)
        : IRequest;
}
