using Athr.Domain.BuildingBlocks;
using Athr.Domain.Common;
using Athr.Domain.TaskWork.Events;
using Athr.Domain.TaskWork.Rules;
using Athr.Domain.Users;

namespace Athr.Domain.TaskWork
{
    public sealed class TaskWork : Entity<TaskWorkId>, IRecoverable
    {
        

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

            RaiseDomainEvent(new TaskWorkCreatedEvent(Id.Value, Name, UserId.Value));
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

            RaiseDomainEvent(new TaskWorkUpdatedEvent(Id.Value));
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void MarkAsDeleted(string deletedBy)
        {
            IsDeleted = true;
            DeletedAt = DateTimeOffset.UtcNow;
            DeletedBy = deletedBy;

            RaiseDomainEvent(new TaskWorkDeletedEvent(Id.Value));
        }

        public void Recover()
        {
            IsDeleted = false;
            DeletedAt = null;
            DeletedBy = null;
        }
        public void UpdatePriority(Priority newPriority)
        {
            var oldPriority = Priority;
            Priority = newPriority;

            RaiseDomainEvent(new PriorityChangedEvent(Id.Value, oldPriority, newPriority));
        }


    }
}

