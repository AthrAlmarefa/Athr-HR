using System.Reflection.Metadata.Ecma335;
using Athr.Application.User.UserRegister;
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
    string identityNumber,
    string? dialCodeId = "SA")
    {
        public static implicit operator UserRegisterCommand(UserRegisterRequest userRegisterRequest) =>
            new UserRegisterCommand(
                userRegisterRequest.email,
                userRegisterRequest.firstName,
                userRegisterRequest.midName,
                userRegisterRequest.lastName,
                userRegisterRequest.password,
                userRegisterRequest.phoneNumber,
                userRegisterRequest.dialCodeId,
                userRegisterRequest.identityType,
                userRegisterRequest.identityNumber
                );
    };
}
