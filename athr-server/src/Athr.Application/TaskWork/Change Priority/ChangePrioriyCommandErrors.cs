using Athr.Application.Exceptions;
namespace Athr.Application.TaskWork.Change_Priorty
{
    public static class ChangePrioriyCommandErrors
    {
        public static readonly ApplicationError InvalidPriority =
             new("ChangeTaskPriority.InvalidPriority", "Invalid priority key.");

        public static readonly ApplicationError PriorityNotFound =
            new("ChangeTaskPriority.PriorityNotFound", "Priority not found.");

        public static readonly ApplicationError TaskNotFound =
            new("ChangeTaskPriority.TaskNotFound", "Task not found.");

        public static readonly ApplicationError SamePriority =
            new("ChangeTaskPriority.SamePriority", "Task already has this priority.");

        
    }
}
