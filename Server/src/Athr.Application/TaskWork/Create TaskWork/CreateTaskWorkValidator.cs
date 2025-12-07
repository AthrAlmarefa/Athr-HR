using FluentValidation;
namespace Athr.Application.TaskWork.Create_TaskWork
{
    public sealed class CreateTaskWorkValidator : AbstractValidator<CreateTaskWorkCommand>
    {
        public CreateTaskWorkValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Name is required.")
                 .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.PriorityKey)
                .NotEmpty().WithMessage("PriorityKey is required.")
                .Must(k => k == 100 || k == 200 || k == 300 || k == 400)
                .WithMessage("Priority must be 100, 200, 300, or 400.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("StartDate is required.")
                .GreaterThan(DateTime.UtcNow).WithMessage("Start date cannot be in the past.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("EndDate is required.")
                .GreaterThan(DateTime.UtcNow).WithMessage("End date cannot be in the past.");

            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("Start date must be before end date.").GreaterThan(DateTime.UtcNow).WithMessage("Start date cannot be in the past."); RuleFor(x => x.EndDate).GreaterThan(DateTime.UtcNow).WithMessage("End date cannot be in the past.");
        }

    }
}