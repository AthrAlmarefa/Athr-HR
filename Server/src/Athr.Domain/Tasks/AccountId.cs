using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.Common;

namespace Athr.Domain.Tasks
{
    public sealed record AccountId : ValueObjectId<Guid>
    {
        public Guid Value { get; }
        private AccountId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Account ID cannot be empty", nameof(value));

            Value = value;
        }

        // Factory methods
        public static AccountId Create() => new(Guid.NewGuid());
        public static AccountId Create(Guid value) => new(value);

        // Implicit operator
        public static implicit operator Guid(AccountId id) => id.Value;
        public static implicit operator AccountId(Guid value) => Create(value);
    }
}
