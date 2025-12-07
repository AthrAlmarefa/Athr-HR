using Athr.Application.Exceptions;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.TaskWork;
using MediatR;


namespace Athr.Application.TaskWork.Change_Priorty
{
    public sealed class ChangePriorityCommandHandler : IRequestHandler<ChangeTaskPriorityCommand>
    {
        private readonly ITaskWorkRepository _taskRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ChangePriorityCommandHandler(
            ITaskWorkRepository taskRepository,
            IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ChangeTaskPriorityCommand request, CancellationToken cancellationToken)
        {

            Priority? newPriority = GetPriorityFromKey(request.PriorityKey);
            if (newPriority is null)
                throw new ApplicationFlowException(new[] { ChangePrioriyCommandErrors.InvalidPriority });


            var taskId = TaskWorkId.Create(request.TaskWorkId);
            var taskWork = await _taskRepository.GetByIdAsync(taskId, cancellationToken);

            if (taskWork is null)
                throw new ApplicationFlowException(new[] { ChangePrioriyCommandErrors.TaskNotFound });

            if (taskWork.Priority.Key == newPriority.Key)
                throw new ApplicationFlowException(new[] { ChangePrioriyCommandErrors.SamePriority });

            taskWork.UpdatePriority(newPriority);

            _taskRepository.Update(taskWork);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        private Priority? GetPriorityFromKey(int key)
        {
            return key switch
            {
                100 => Priority.Low,
                200 => Priority.Medium,
                300 => Priority.High,
                400 => Priority.Critical,
                _ => null
            };
        }
    }
}