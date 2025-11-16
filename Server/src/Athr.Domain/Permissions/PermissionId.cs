using Athr.Domain.Common;

namespace Athr.Domain.Permissions;

public sealed record PermissionId : ValueObjectId
{
    private PermissionId(Guid value) : base(value)
    {
    }

    private PermissionId() { }

    public static PermissionId CreateUnique()
    {
        return new PermissionId(Guid.NewGuid());
    }

    public static PermissionId Create(Guid value)
    {
        return new PermissionId(value);
    }

    public static implicit operator PermissionId(Guid value) => Create(value);
}
