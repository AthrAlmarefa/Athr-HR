namespace Athr.Domain.Permissions;

public interface IPermissionRepository
{
    IQueryable<Permission> All();
}
