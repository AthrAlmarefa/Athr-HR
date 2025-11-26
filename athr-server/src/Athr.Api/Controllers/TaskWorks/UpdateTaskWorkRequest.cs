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
    )
    {
        public static implicit operator UpdateTaskWorkCommand(UpdateTaskWorkRequest request)
        {
            
            return new UpdateTaskWorkCommand(
                request.TaskId,
                request.Name,
                request.UserId,
                request.PriorityKey,
                request.StartDate,
                request.EndDate,
                request.Description
            );
        }

    }
}
