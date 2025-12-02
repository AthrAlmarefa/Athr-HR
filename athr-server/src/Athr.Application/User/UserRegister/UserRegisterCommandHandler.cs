using Athr.Application.Abstractions.Behaviors;
using Athr.Application.Abstractions.Messaging;
using Athr.Application.User.UserRegister;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Enumerations;
using Athr.Domain.Users;
using BCrypt.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Athr.Application.Users.UserRegister;

public sealed class UserRegisterCommandHandler : ICommandHandler<UserRegisterCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UserRegisterCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Email: {request.email}");
        Console.WriteLine($"Password: {request.password}");

        var userId = AccountId.CreateUnique();

        // Check for unique conflicts
        await _userRepository.UniqueConflicts(
            userId,
            request.email,
            request.phoneNumber,
            string.Empty,
            cancellationToken);

        if (!IdentityType.TryFromName(request.identityType, out var identityType))
        {
            throw new ApplicationException($"Invalid identity type: {request.identityType}. Valid values: ST, AD, INS, PR");
        }

        //temp untill externally provided
        var tempIdentityNumber = $"TEMP-{userId.Value}";

        // Hash password
        var hashedPassword = PasswordHasher.HashPassword(request.password);

        // Create user instance
        var user = UserEntity.CreateInstance(
            request.firstName,
            request.midName,
            request.lastName,
            request.email,
            hashedPassword,
            request.phoneNumber,
            tempIdentityNumber,
            request.dialCodeId);
        user.SetIdentityId(identityType); 

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id.Value;
    }
}