using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.TaskWork.Rules
{
    internal class TaskWorkEndDateMustBeAfterStartDate:IBusinessRule
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        public TaskWorkEndDateMustBeAfterStartDate(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public bool IsBroken() => _endDate <= _startDate;

        public Error Error => new("TaskWorkEndDateMustBeAfterStartDate", "End date must be after start date.");
    
    }
}
