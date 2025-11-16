using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Athr.Infrastructure.Authentication;

internal sealed class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly AuthenticationOptions _authenticationOptions;
    private readonly ILogger<JwtBearerOptions> logger;

    public JwtBearerOptionsSetup(IOptions<AuthenticationOptions> authenticationOptions,
        ILogger<JwtBearerOptions> logger)
    {
        _authenticationOptions = authenticationOptions.Value;
        this.logger = logger;
    }

    public void Configure(JwtBearerOptions options)
    {
        options.Audience = _authenticationOptions.Audience;
        var keyBytes = Encoding.UTF8.GetBytes(_authenticationOptions.SecretKey);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = true,
            ValidIssuer = _authenticationOptions.ValidIssuer,
            ValidateAudience = true,
            ValidAudience = _authenticationOptions.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                logger.LogError(context.Exception, "Authentication failed");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                logger.LogInformation("Token validated successfully");
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                Console.WriteLine($"⚠️ OnChallenge triggered: {context.Error}, {context.ErrorDescription}");
                return Task.CompletedTask;
            },
            OnMessageReceived = context =>
            {
                logger.LogInformation("{Message}", $"{context.Token} Token received");
                return Task.CompletedTask;
            }
        };
    }


    public void Configure(string? name, JwtBearerOptions options)
    {
        Configure(options);
    }
}
