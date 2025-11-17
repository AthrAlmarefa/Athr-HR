
using Athr.Application.Exceptions;

namespace Athr.Application.Users.UserRegister
{
    public sealed class UserRegisterCommandErrors
    {
        public static readonly ApplicationError IsExistBefore = new(
            $"{nameof(UserRegisterCommand)}.IsExistBefore", "User Is Exist Before"
            );
    }
}
