using Athr.Application.Abstractions.Messaging;
using Athr.Domain.Enumerations;
namespace Athr.Application.User.UserRegister
{
    public sealed record UserRegisterCommand(
        string email,
        string firstName,
        string midName,
        string lastName,
        string password,
        string phoneNumber,
        string dialCodeId,
        string identityType,
        string identityNumber): ICommand<Guid>;
}
