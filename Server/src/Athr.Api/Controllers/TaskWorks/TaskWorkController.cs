using Asp.Versioning;
using Athr.Application.TaskWork.Create_TaskWork;
using Athr.Application.TaskWork.UpdateTaskWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Athr.Api.Controllers.TaskWorks
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/taskwork")]
    public class TaskWorkController 
    {
        private readonly ISender _sender;

        public TaskWorkController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<Guid> CreateTaskWork([FromBody] CreateTaskWorkRequest request)
        {
            CreateTaskWorkCommand command = request;
            var taskId = await _sender.Send(command);
            return taskId;
        }
        [HttpPut("{taskId:guid}/user/{userId:guid}")]
        public async Task<Guid> UpdateTask(Guid taskId, Guid userId, [FromBody] UpdateTaskWorkRequest request)
        {
            var command = new UpdateTaskWorkCommand(
                taskId,
                request.Name,
                userId,
                request.PriorityKey,
                request.StartDate,
                request.EndDate,
                request.Description
            );

            return await _sender.Send(command);
        }
    }
}
