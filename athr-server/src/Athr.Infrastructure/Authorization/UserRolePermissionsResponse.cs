using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.BusinessRoles;
using Athr.Domain.Users.Authorization;

namespace Athr.Infrastructure.Authorization
{
    internal sealed class UserRolePermissionsResponse
    {
        public Guid UserId { get; init; }
        public string RoleName { get; init; }
        public string IdentityId { get; init; } = string.Empty;
        public List<BusinessRolesPermission> BusinessRoles { get; init; } = [];
    }
}
