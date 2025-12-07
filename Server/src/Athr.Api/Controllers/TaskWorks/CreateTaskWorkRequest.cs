using Athr.Application.TaskWork.Create_TaskWork;

namespace Athr.Api.Controllers.TaskWorks
{
    public sealed record CreateTaskWorkRequest(
       string Name,
       Guid UserId,
       int PriorityKey,
       DateTime StartDate,
       DateTime EndDate,
       string Description
   )
    {
        public static implicit operator CreateTaskWorkCommand(CreateTaskWorkRequest request)
        {
            return new CreateTaskWorkCommand
            {
                Name = request.Name,
                UserId = request.UserId,
                PriorityKey = request.PriorityKey,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Description = request.Description
            };
        }
    }
}