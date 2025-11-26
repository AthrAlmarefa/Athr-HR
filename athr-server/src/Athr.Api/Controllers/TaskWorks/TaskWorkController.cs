using Asp.Versioning;
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
        [HttpPut]
        public async Task<Guid> UpdateTask(UpdateTaskWorkRequest request)
        {
            UpdateTaskWorkCommand command = request;
            return await _sender.Send(command);
        }

    }

}
