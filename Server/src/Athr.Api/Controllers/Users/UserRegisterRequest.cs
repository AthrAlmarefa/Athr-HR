using Athr.Application.Users.UserRegister;

namespace Athr.Api.Controllers.Users
{
    public sealed record UserRegisterRequest(string Email,
        string FirstName,
        string MidName,
        string PhoneNumber,
        string DialCodeId,
        string LastName,
        string Password)
    {
        public static implicit operator UserRegisterCommand(UserRegisterRequest request)
            => new(request.Email, request.FirstName, request.LastName, request.PhoneNumber, request.DialCodeId, request.LastName, request.Password);
    }
}
