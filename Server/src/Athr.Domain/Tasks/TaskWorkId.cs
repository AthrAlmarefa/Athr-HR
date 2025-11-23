using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.Common;

namespace Athr.Domain.Tasks
{
    public sealed record TaskWorkId : ValueObjectId<Guid>
    {
        public Guid Value { get; }

        private TaskWorkId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Task ID cannot be empty", nameof(value));

            Value = value;
        }

        // Factory methods
        public static TaskWorkId Create() => new(Guid.NewGuid());
        public static TaskWorkId Create(Guid value) => new(value);

        // Implicit operator
        public static implicit operator Guid(TaskWorkId id) => id.Value;
        public static implicit operator TaskWorkId(Guid value) => Create(value);
    }
}
