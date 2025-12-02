using Athr.Domain.Enumerations;

namespace Athr.Api.Controllers.Users
{
    public sealed record UserRegisterRequest(
    string firstName,
    string midName,
    string lastName,
    string email,
    string password,
    string phoneNumber,
    string identityType,
    string? dialCodeId = "SA");
}
