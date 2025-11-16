using Athr.Domain.Common;

namespace Athr.Domain.Qualification;

public sealed record QualificationId : ValueObjectId<int>
{
    private QualificationId(int value) : base(value)
    {
    }

    private QualificationId() { }

    public static QualificationId Create(int value) => new QualificationId(value);

    public static implicit operator QualificationId(int value) => Create(value);
}
