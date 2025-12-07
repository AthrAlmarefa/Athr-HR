using Athr.Application.Exceptions;

namespace Athr.Application.TaskWork.UpdateTaskWork
{
    public static class UpdateTaskWorkCommandErrors
    {
        public static readonly ApplicationError TaskNotFound =
            new("UpdateTaskWork.TaskNotFound", "Task not found.");


        public static readonly ApplicationError InvalidPriority =
            new("UpdateTaskWork.InvalidPriority", "Invalid priority key.");

        public static readonly ApplicationError InvalidDateRange =
            new("UpdateTaskWork.InvalidDateRange", "Start date must be before end date.");

        public static readonly ApplicationError NameAlreadyExists =
            new("UpdateTaskWork.NameAlreadyExists", "A task with this name already exists.");

        public static readonly ApplicationError UserNotFound =
            new("UpdateTaskWork.UserNotFound", "User not found.");
    }

}