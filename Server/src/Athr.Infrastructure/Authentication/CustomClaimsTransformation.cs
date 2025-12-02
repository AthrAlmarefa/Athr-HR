using Athr.Infrastructure.Authentication;
using Athr.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Athr.Infrastructure.Authentication
{
    internal sealed class CustomClaimsTransformation : IClaimsTransformation
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomClaimsTransformation(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity?.IsAuthenticated != true ||
                principal.HasClaim(c => c.Type == ClaimTypes.Role))
                return principal;

            using var scope = _serviceProvider.CreateScope();
            var authorizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();

            try
            {
                var userId = principal.GetUserId();
                var userRolePermissions = await authorizationService
                    .GetBusinessRolesForUserAsync(userId.ToString());

                var claimsIdentity = new ClaimsIdentity();

                foreach (var role in userRolePermissions.BusinessRoles)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
                }

                principal.AddIdentity(claimsIdentity);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Claims transformation failed");
            }

            return principal;
        }
    }
}