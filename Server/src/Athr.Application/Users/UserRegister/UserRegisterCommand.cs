using Athr.Application.Abstractions.Messaging;

namespace Athr.Application.Users.UserRegister
{
    public sealed record UserRegisterCommand(
        string Email,
        string FirstName,
        string MidName,
        string PhoneNumber,
        string DialCodeId,
        string LastName,
        string Password) : ICommand<Guid>;
}
