using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Common;

namespace Athr.Domain.Tasks
{
    public sealed class TaskWork : Entity<TaskWorkId>
    {
        public string Name { get; private set; }
        public AccountId UserId { get; private set; }
        public Priority Priority { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Description? Description { get; private set; }

        private TaskWork() { }
        private TaskWork(TaskWorkId id, string name,
           AccountId userId,
           Priority priority,
           DateTime startDate,
           DateTime endDate,
           Description description)
        {
            Name = name;
            UserId = userId;
            Priority = priority;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }
        public static TaskWork Create(
           string name,
           AccountId userId,
           Priority priority,
           DateTime startDate,
           DateTime endDate,
           Description description)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Task name cannot be empty", nameof(name));

            if (startDate >= endDate)
                throw new ArgumentException("End date must be after start date", nameof(endDate));

            var task = new TaskWork(
            id: TaskWorkId.Create(),
            name.Trim(),
            userId,
            priority,
            startDate,
            endDate,
            description
            );

            //task.RaiseDomainEvent(new TaskCreatedEvent(task.Id, task.UserId));

            return task;
        }

        public bool IsDeleted { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }
        public string? DeletedBy { get; private set; }
        public void Recover()
        {
            IsDeleted = false;
            DeletedAt = null;
            DeletedBy = null;
        }
        public void MarkAsDeleted()
        {
            IsDeleted = true;
            DeletedAt = DateTimeOffset.UtcNow;
        }

    }
}
