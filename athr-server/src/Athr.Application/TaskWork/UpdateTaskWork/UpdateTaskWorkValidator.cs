using FluentValidation;
namespace Athr.Application.TaskWork.UpdateTaskWork
{
    public sealed class UpdateTaskWorkValidator : AbstractValidator<UpdateTaskWorkCommand>
    {
        public UpdateTaskWorkValidator()
        {
            RuleFor(x => x.TaskId)
                .NotEmpty()
                .WithMessage("TaskId is required.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Description)
                .MaximumLength(2000);

            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.PriorityKey)
                .Must(k => k == 100 || k == 200 || k == 300 || k == 400)
                .WithMessage("Priority must be 100, 200, 300, or 400.");

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate)
                .WithMessage("Start date must be before end date.")
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Start date cannot be in the past.");

            RuleFor(x => x.EndDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("End date cannot be in the past.");

            RuleFor(x => x)
                .Must(x => (x.EndDate - x.StartDate).TotalHours >= 1)
                .WithMessage("Task duration must be at least 1 hour.");
        }
    }
}
