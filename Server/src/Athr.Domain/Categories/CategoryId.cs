using Athr.Domain.BuildingBlocks;
using Athr.Domain.Common;

namespace Athr.Domain.Categories;

public sealed record CategoryId : ValueObjectId
{
    private CategoryId(Guid value) : base(value)
    {
    }

    private CategoryId() { }


    public static CategoryId CreateUnique()
    {
        return new CategoryId(Guid.NewGuid());
    }

    public static CategoryId Create(Guid value)
    {
        return new CategoryId(value);
    }

    public static implicit operator CategoryId(Guid value) => Create(value);
}
