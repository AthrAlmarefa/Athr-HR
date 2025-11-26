using Athr.Application.Exceptions;
namespace Athr.Application.TaskWork.Create_TaskWork
{
    public static class CreateTaskWorkCommandErrors
    {
        public static readonly ApplicationError InvalidPriority =
             new("CreateTaskWork.InvalidPriority", "Invalid priority key.");

        public static readonly ApplicationError PriorityNotFound =
            new("CreateTaskWork.PriorityNotFound", "Priority not found.");

        public static readonly ApplicationError InvalidDateRange =
            new("CreateTaskWork.InvalidDateRange", "Start date must be before end date.");

        public static readonly ApplicationError StartDateInPast =
            new("CreateTaskWork.StartDateInPast", "Start date cannot be in the past.");

        public static readonly ApplicationError NameAlreadyExists =
            new("CreateTaskWork.NameAlreadyExists", "A task with this name already exists.");

        public static readonly ApplicationError UserNotFound =
            new("CreateTaskWork.UserNotFound", "User not found.");
    }
}

