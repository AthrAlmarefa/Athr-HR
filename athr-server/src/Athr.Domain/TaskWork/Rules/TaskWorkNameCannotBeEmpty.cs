using Athr.Domain.BuildingBlocks;
namespace Athr.Domain.TaskWork.Rules
{
    public class TaskWorkNameCannotBeEmpty: IBusinessRule
    {
        private readonly string _name;

        public TaskWorkNameCannotBeEmpty(string name)
        {
            _name = name;
        }

        public bool IsBroken() => string.IsNullOrWhiteSpace(_name);

        public Error Error => new("TaskWorkNameCannotBeEmpty", "Task name cannot be empty.");
    }
}

