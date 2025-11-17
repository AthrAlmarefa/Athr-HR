using Athr.Application.Abstractions.Messaging;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Users;

namespace Athr.Application.Users.UserRegister
{
    public sealed class UserRegisterCommandHandler(IUnitOfWork _unitOfWork, IUserRepository _userRepository) : ICommandHandler<UserRegisterCommand, Guid>
    {
        public async Task<Guid> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var userId = AccountId.CreateUnique();
            await _userRepository.UniqueConflicts(userId, request.Email, request.PhoneNumber, "", cancellationToken);

            var user = UserEntity.CreateInstance(request.FirstName, request.MidName, request.LastName, request.Email,
                request.PhoneNumber, request.Email, request.DialCodeId);

            user.ChangePassword(request.Password);

            await _userRepository.AddAsync(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user.Id.Value;
        }
    }
}
