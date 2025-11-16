using Athr.Application.Abstractions.Caching;
using Athr.Application.Exceptions;
using Athr.Domain.BusinessRoles;
using Athr.Domain.Users;
using Athr.Infrastructure.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Athr.Infrastructure.Authorization;

internal sealed class AuthorizationService
{
    private readonly ICacheService _cacheService;
    private readonly ApplicationDbContext _dbContext;

    public AuthorizationService(ApplicationDbContext dbContext, ICacheService cacheService)
    {
        _dbContext = dbContext;
        _cacheService = cacheService;
    }

    public async Task<UserRolePermissionsResponse> GetBusinessRolesForUserAsync(string identityId)
    {
        string cacheKey = $"auth:Role-{identityId}";
        UserRolePermissionsResponse? cachedTeams = await _cacheService.GetAsync<UserRolePermissionsResponse>(cacheKey);

        if (cachedTeams is not null)
        {
            return cachedTeams;
        }

        var accountId = AccountId.Create(new Guid(identityId));

        UserEntity user = await _dbContext.Set<UserEntity>().Where(u => u.Id == accountId).Include(x => x.BusinessRoles).FirstOrDefaultAsync()
                    ?? throw new ApplicationFlowException([new ApplicationError("UserNotFound", "User not found")]);

        if (!user.BusinessRoles.Any())
            throw new ApplicationFlowException([new ApplicationError("RoleNotFound", "User Role not found")]);

        var role = await _dbContext.Set<BusinessRole>().FirstAsync(bR => bR.Id.Equals(user.BusinessRoles.First()));

        var userRolePermissions = new UserRolePermissionsResponse { UserId = user.Id.Value, RoleName = role.Alias, BusinessRoles = user.BusinessPermissions.ToList() };

        await _cacheService.SetAsync(cacheKey, userRolePermissions);

        return userRolePermissions;
    }

    public async Task<HashSet<string>> GetPermissionsForUserAsync(string identityId)
    {
        string cacheKey = $"auth:permissions-{identityId}";
        HashSet<string>? cachedPermissions = await _cacheService.GetAsync<HashSet<string>>(cacheKey);

        if (cachedPermissions is not null)
        {
            return cachedPermissions;
        }

        var accountId = AccountId.Create(new Guid(identityId));

        UserEntity user = _dbContext.Set<UserEntity>().Include(x => x.BusinessPermissions).FirstOrDefault(u => u.Id.Equals(accountId))
                                ?? throw new ApplicationFlowException([new ApplicationError("UserNotFound", "User not found")]);

        var permissionsSet = user.BusinessPermissions.Select(p => p.Name).ToHashSet();

        await _cacheService.SetAsync(cacheKey, permissionsSet);

        return permissionsSet;
    }


    public string GenerateJwtToken(ClaimsPrincipal principal, AuthenticationOptions _jwtOptions)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = (ClaimsIdentity)principal.Identity!,
            Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpiryMinutes),
            SigningCredentials = creds,
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(securityToken);
    }
}
