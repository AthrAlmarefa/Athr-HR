using Athr.Domain.BuildingBlocks;
using Athr.Domain.Common;
using Athr.Domain.TaskWork.Events;
using Athr.Domain.TaskWork.Rules;
using Athr.Domain.Users;

namespace Athr.Domain.TaskWork
{
    public sealed class TaskWork : Entity<TaskWorkId>, IRecoverable, IHasEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public string Name { get; private set; }
        public AccountId UserId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Priority Priority { get; private set; }
        public Description Description { get; private set; }

        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        private TaskWork() { }

        private TaskWork(TaskWorkId id, string name, AccountId userId, Priority priority, DateTime startDate, DateTime endDate, Description description)
            : base(id)
        {
            CheckRule(new TaskWorkNameCannotBeEmpty(name));
            CheckRule(new TaskWorkEndDateMustBeAfterStartDate(startDate, endDate));
            Name = name;
            UserId = userId;
            Priority = priority;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;

            AddDomainEvent(new TaskWorkCreatedEvent(this));
        }

        public static TaskWork CreateInstance(string name, AccountId userId, Priority priority, DateTime startDate, DateTime endDate, Description description)
        {
            return new TaskWork(TaskWorkId.CreateUnique(), name, userId, priority, startDate, endDate, description);
        }

        public void Update(string name, Priority priority, DateTime startDate, DateTime endDate, Description description)
        {
            CheckRule(new TaskWorkNameCannotBeEmpty(name));
            CheckRule(new TaskWorkEndDateMustBeAfterStartDate(startDate, endDate));

            Name = name;
            Priority = priority;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;

            AddDomainEvent(new TaskWorkUpdatedEvent(this));
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;

        public void MarkAsDeleted()
        {
            IsDeleted = true;
            DeletedAt = DateTimeOffset.UtcNow;
            AddDomainEvent(new TaskWorkDeletedEvent(this));
        }

        public void Recover()
        {
            IsDeleted = false;
            DeletedAt = null;
            DeletedBy = null;
        }
        public void UpdatePriority(Priority newPriority)
        {
            if (Priority.Key != newPriority.Key)
            {
                var oldPriority = Priority;
                Priority = newPriority;
                AddDomainEvent(new PriorityChangedEvent(this, oldPriority, newPriority));
            }
        }

        public void AddDomainEvent(IDomainEvent @event) => _domainEvents.Add(@event);
        public void ClearDomainEvents() => _domainEvents.Clear();
        public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();

        private void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
                throw new BusinessRuleValidationException(rule);
        }
    }
}

