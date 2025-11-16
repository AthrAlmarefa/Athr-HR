namespace Athr.Infrastructure.Authentication;

public sealed class AuthenticationOptions
{
    public string Authority { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;

    public string SecretKey { get; set; } = string.Empty;

    public string ValidIssuer { get; set; } = string.Empty;
    public int ExpiryMinutes { get; set; }
}
