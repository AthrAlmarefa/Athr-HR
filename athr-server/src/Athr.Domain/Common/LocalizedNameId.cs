namespace Athr.Domain.Common;

public sealed record LocalizedNameId : ValueObjectId<int>
{
    private LocalizedNameId(int value) : base(value)
    {
    }

    private LocalizedNameId() { }

    public static LocalizedNameId Create(int value) => new LocalizedNameId(value);

    public static implicit operator LocalizedNameId(int value) => Create(value);
}
