using Athr.Application.Abstractions.Authentication;
using Athr.Domain.Users;
using Athr.Infrastructure.Authentication.Models;
using System.Net.Http.Json;

namespace Athr.Infrastructure.Authentication;

internal sealed class AuthenticationService : IAuthenticationService
{
    private const string PasswordCredentialType = "password";

    private readonly HttpClient _httpClient;

    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> RegisterAsync(UserEntity user, string password, CancellationToken cancellationToken = default)
    {
        var userRepresentationModel = UserRepresentationModel.FromUser(user);

        userRepresentationModel.Credentials =
        [
            new CredentialRepresentationModel { Value = password, Temporary = false, Type = PasswordCredentialType }
        ];

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            "users", userRepresentationModel, cancellationToken);

        return ExtractIdentityIdFromLocationHeader(response);
    }

    public async Task<bool> CheckUserExistsAsync(string userName, string? email = default,
        CancellationToken cancellationToken = default)
    {
        //var query = new Dictionary<string, string>();

        //if (!string.IsNullOrWhiteSpace(userName))
        //{
        //    query["username"] = userName;
        //}

        //if (!string.IsNullOrWhiteSpace(email))
        //{
        //    query["email"] = email;
        //}

        //string queryString = string.Join("&", query.Select(q => $"{q.Key}={Uri.EscapeDataString(q.Value)}"));

        //string requestUrl = $"{_keycloakOptions.Value.CheckUserExistsUrl}?{queryString}";

        //HttpResponseMessage response = await _httpClient.GetAsync(requestUrl, cancellationToken);

        //response.EnsureSuccessStatusCode();

        //string content = await response.Content.ReadAsStringAsync(cancellationToken);

        //int userCount = int.Parse(content, CultureInfo.InvariantCulture);

        //return userCount > 0;

        return true;
    }

    private static string ExtractIdentityIdFromLocationHeader(HttpResponseMessage httpResponseMessage)
    {
        const string usersSegmentName = "users/";

        string locationHeader = httpResponseMessage.Headers.Location?.PathAndQuery ??
                                throw new InvalidOperationException("Location header can't be null");

        int userSegmentValueIndex = locationHeader.IndexOf(
            usersSegmentName, StringComparison.InvariantCultureIgnoreCase);

        string userIdentityId = locationHeader.Substring(userSegmentValueIndex + usersSegmentName.Length);

        return userIdentityId;
    }
}
