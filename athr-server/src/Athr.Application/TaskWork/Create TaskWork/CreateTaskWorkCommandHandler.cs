using Athr.Application.Abstractions.Messaging;
using Athr.Application.Exceptions;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Common;
using Athr.Domain.TaskWork;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;
namespace Athr.Application.TaskWork.Create_TaskWork
{
    public sealed class CreateTaskWorkCommandHandler : ICommandHandler<CreateTaskWorkCommand, Guid>
    {
        private readonly ITaskWorkRepository _taskRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepo;
        public CreateTaskWorkCommandHandler(
            ITaskWorkRepository taskRepo,
              IUserRepository userRepo,
            IUnitOfWork unitOfWork)
        {
            _taskRepo = taskRepo;
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }



        public async Task<Guid> Handle(CreateTaskWorkCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId == Guid.Empty)
                throw new ApplicationFlowException(new[] { CreateTaskWorkCommandErrors.UserNotFound });
            var accountId = AccountId.Create(request.UserId);

            var user = await _userRepo.GetByIdAsync(accountId, cancellationToken);
            if (user is null)
                throw new ApplicationFlowException(new[] { CreateTaskWorkCommandErrors.UserNotFound });
            Priority priority = request.PriorityKey switch
            {
                100 => Priority.Low,
                200 => Priority.Medium,
                300 => Priority.High,
                400 => Priority.Critical,
                _ => throw new ApplicationFlowException(new[] { CreateTaskWorkCommandErrors.InvalidPriority })
            };


            if (request.StartDate >= request.EndDate)
                throw new ApplicationFlowException(new[] { CreateTaskWorkCommandErrors.InvalidDateRange });

         
            bool exists = await _taskRepo.All().AnyAsync(t => t.Name == request.Name, cancellationToken);
            if (exists)
                throw new ApplicationFlowException(new[] { new ApplicationError("CreateTaskWork.NameAlreadyExists", "A task with this name already exists.") });

            Description description = Description.Create(request.Description);
            AccountId userId = AccountId.Create(request.UserId);

            var task = Athr.Domain.TaskWork.TaskWork.CreateInstance(
                request.Name,
                userId,
                priority,
                request.StartDate,
                request.EndDate,
                description
            );

            await _taskRepo.AddAsync(task);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return task.Id.Value;
        }

    }
}
