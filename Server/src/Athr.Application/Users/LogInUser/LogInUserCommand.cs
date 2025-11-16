using Athr.Application.Abstractions.Messaging;

namespace Athr.Application.Users.LogInUser;

public sealed record LogInUserCommand(string Email, string Password) : ICommand<AccessTokenResponse>;
