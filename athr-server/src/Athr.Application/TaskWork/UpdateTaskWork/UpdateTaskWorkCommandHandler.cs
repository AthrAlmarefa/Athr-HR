using Athr.Application.Abstractions.Messaging;
using Athr.Application.Exceptions;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Common;
using Athr.Domain.TaskWork;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Athr.Application.TaskWork.UpdateTaskWork
{
    public sealed class UpdateTaskWorkCommandHandler : ICommandHandler<UpdateTaskWorkCommand, Guid>
    {
        private readonly ITaskWorkRepository _taskRepo;
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaskWorkCommandHandler(
            ITaskWorkRepository taskRepo,
            IUserRepository userRepo,
            IUnitOfWork unitOfWork)
        {
            _taskRepo = taskRepo;
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateTaskWorkCommand request, CancellationToken cancellationToken)
        {
      
            var accountId = AccountId.Create(request.UserId);
            var user = await _userRepo.GetByIdAsync(accountId, cancellationToken);

            if (user is null)
                throw new ApplicationFlowException(new[] { UpdateTaskWorkCommandErrors.UserNotFound });

            TaskWorkId taskId;
            try
            {
                taskId = TaskWorkId.Create(request.TaskId);
            }
            catch
            {
                throw new ApplicationFlowException(new[] { UpdateTaskWorkCommandErrors.TaskNotFound });
            }

           
            var task = await _taskRepo.GetByIdAsync(taskId, cancellationToken);

            if (task is null)
                throw new ApplicationFlowException(new[] { UpdateTaskWorkCommandErrors.TaskNotFound });

          
            var priority = request.PriorityKey switch
            {
                100 => Priority.Low,
                200 => Priority.Medium,
                300 => Priority.High,
                400 => Priority.Critical,
                _ => throw new ApplicationFlowException(new[] { UpdateTaskWorkCommandErrors.InvalidPriority })
            };

            bool exists = await _taskRepo.All()
     .Where(t => !t.IsDeleted)
     .AsNoTracking()
     .AnyAsync(t => t.Name == request.Name &&t.Id != taskId, cancellationToken);

            if (exists)
                throw new ApplicationFlowException(new[] { UpdateTaskWorkCommandErrors.NameAlreadyExists });

            task.Update(
                request.Name,
                priority,
                request.StartDate,
                request.EndDate,
                Description.Create(request.Description)
            );

            _taskRepo.Update(task);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return task.Id.Value;
        }

    }
}
    