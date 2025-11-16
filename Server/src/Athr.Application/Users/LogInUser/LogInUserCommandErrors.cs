using Athr.Application.Exceptions;

namespace Athr.Application.Users.LogInUser;

public static class LogInUserCommandErrors
{
    public static readonly ApplicationError InvalidCredentials = new(
        $"{nameof(LogInUserCommand)}.InvalidCredentials", "Invalid credentials.");

    public static readonly ApplicationError InvalidLoginUser = new(
        $"{nameof(LogInUserCommand)}.InvalidLoginUser", "Invalid Email Or Password.");
}
