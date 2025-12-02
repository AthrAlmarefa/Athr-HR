using Athr.Application.Abstractions.Behaviors;
using Athr.Application.Abstractions.Messaging;
using Athr.Application.Exceptions;
using Athr.Application.User.UserRegister;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.BusinessRoles;
using Athr.Domain.Enumerations;
using Athr.Domain.Users;
using Athr.Domain.Users.Authorization;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Athr.Application.Users.UserRegister;

public sealed class UserRegisterCommandHandler(
        IUnitOfWork _unitOfWork,
        IUserRepository _userRepository,
        IBusinessRoleRepository _businessRuleRepository) : ICommandHandler<UserRegisterCommand, Guid>
{
    public async Task<Guid> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        var userId = AccountId.CreateUnique();

        // Check for unique conflicts
        await _userRepository.UniqueConflicts(
            userId,
            request.email,
            request.phoneNumber,
            request.identityNumber,
            cancellationToken);

        //if (!IdentityType.TryFromName(request.identityType, out var identityType))
        //{
        //    throw new ApplicationException($"Invalid identity type: {request.identityType}. Valid values: ST, AD, INS, PR");
        //}

        // Hash password
        var hashedPassword = PasswordHasher.HashPassword(request.password);

        // Create user instance
        var user = UserEntity.CreateInstance(
            request.firstName,
            request.midName,
            request.lastName,
            request.email,
            request.phoneNumber,
            request.identityNumber);

        user.ChangePassword(hashedPassword);

        var businessRole = await _businessRuleRepository.All().SingleOrDefaultAsync(r => r.Alias.Equals(Constants.RoleAdminAlias))
            ?? throw new ApplicationFlowException([UserRegisterCommandErrors.InvalidBusinessRole]);
        
        user.AddBusinessRole(businessRole.Id);

        var permissions = businessRole.AllowedPermissions.Select(p => BusinessRolesPermission.Create(p.PermissionId,businessRole.Id,p.Name)).ToList()
                      ?? throw new ApplicationFlowException([UserRegisterCommandErrors.InvalidBusinessRole]);

        user.AssignPermissions(permissions);

        user.SetIdentityId(IdentityType.Admin); 
        
        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id.Value;
    }
}