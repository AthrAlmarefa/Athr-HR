using Athr.Application.Exceptions;

namespace Athr.Application.Users.LogInUser;

public static class UserLoginCommandErrors
{
    public static readonly ApplicationError InvalidCredentials = new(
        $"{nameof(UserLoginCommand)}.InvalidCredentials", "Invalid credentials.");

    public static readonly ApplicationError InvalidLoginUser = new(
        $"{nameof(UserLoginCommand)}.InvalidLoginUser", "Invalid Email Or Password.");
}
