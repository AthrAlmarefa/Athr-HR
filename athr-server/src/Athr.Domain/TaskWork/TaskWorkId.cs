using Athr.Domain.Common;
namespace Athr.Domain.TaskWork
{
    public sealed record TaskWorkId: ValueObjectId
    {
        private TaskWorkId(Guid value) : base(value)
        {
        }

        private TaskWorkId() { }

        public static TaskWorkId Create(Guid value)
        {
            return new TaskWorkId(value);
        }
        public static TaskWorkId CreateUnique()
        {
            return new TaskWorkId(Guid.NewGuid());
        }

        public static implicit operator TaskWorkId(Guid value)
            => Create(value);

    }
}
