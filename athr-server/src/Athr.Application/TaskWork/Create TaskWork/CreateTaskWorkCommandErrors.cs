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

        public static readonly ApplicationError NameAlreadyExistsForUser =
            new("CreateTaskWork.NameAlreadyExistsForUser", "You already have a task with this name.");

        public static readonly ApplicationError UserNotFound =
            new("CreateTaskWork.UserNotFound", "User not found.");
        public static readonly ApplicationError SamePriorityExists =
           new("CreateTaskWork.SamePriorityExists", "A task with this priority already exists for this user.");
    }
}

