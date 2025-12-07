using Asp.Versioning;
using Athr.Application.TaskWork.Change_Priorty;
using Athr.Application.TaskWork.Create_TaskWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Athr.Api.Controllers.TaskWorks
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
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
        [HttpPatch("{id:guid}/priority")]
        public async Task<IActionResult> ChangePriority(Guid id, [FromBody] ChangeTaskPriorityRequest request)
        {
            var command = new ChangeTaskPriorityCommand(id, request.PriorityKey);

            await _sender.Send(command);

            return NoContent();
        }
    }
}
