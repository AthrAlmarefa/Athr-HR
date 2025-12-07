using Athr.Application.TaskWork.UpdateTaskWork;

namespace Athr.Api.Controllers.TaskWorks
{
    public sealed record UpdateTaskWorkRequest
    (
        Guid TaskId,
        string Name,
        Guid UserId,
        int PriorityKey,
        DateTime StartDate,
        DateTime EndDate,
        string Description
    );
}