using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Permissions;

public sealed class Permission : Entity<PermissionId>
{
    private Permission(PermissionId id, string name, List<string> tags, string useCase, bool AdminMustHave,
        bool userMustHave, bool visible)
    {
        Id = id;
        Name = name;
        Tags = tags;
        UseCase = useCase;
        AdminMustHave = AdminMustHave;
        UserMustHave = userMustHave;
        Visible = visible;
    }

    public static Permission Create(Guid id, string name, List<string> tags, string useCase, bool AdminMustHave,
        bool userMustHave = false, bool visible = true)
    {
        return new Permission(PermissionId.Create(id), name, tags, useCase, AdminMustHave, userMustHave, visible);
    }

    public string Name { get; private set; }
    public string UseCase { get; private set; }
    public List<string> Tags { get; private set; }
    public bool AdminMustHave { get; private set; }
    public bool UserMustHave { get; private set; }
    public bool Visible { get; private set; }
}
