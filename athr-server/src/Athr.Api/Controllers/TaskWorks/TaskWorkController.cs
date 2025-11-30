using Asp.Versioning;
using Athr.Application.TaskWork.Change_Priorty;
using Athr.Application.TaskWork.Create_TaskWork;
using Athr.Application.TaskWork.UpdateTaskWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Athr.Api.Controllers.TaskWorks
{

        [ApiController]
        [ApiVersion("1.0")]
        [Route("api/v{version:apiVersion}/taskwork")]
        public class TaskWorkController : ControllerBase
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

        [HttpPatch("{id:guid}/priority")]
        public async Task<IActionResult> ChangePriority(Guid id, [FromBody] ChangeTaskPriorityRequest request)
        {
            var command = new ChangeTaskPriorityCommand(id, request.PriorityKey);

            await _sender.Send(command);

            return NoContent();
        }
    }

}
