using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static Athr.Infrastructure.Authentication.JwtService;

namespace Athr.Infrastructure.Authentication;

internal sealed class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions;
    private readonly ILogger<JwtBearerOptions> logger;

    public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions,
        ILogger<JwtBearerOptions> logger)
    {
        _jwtOptions = jwtOptions.Value;
        this.logger = logger;
    }

    public void Configure(JwtBearerOptions options)
    {
        options.Audience = _jwtOptions.Audience;
        var keyBytes = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = true,
            ValidIssuer = _jwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = _jwtOptions.Audience,
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
            OnTokenValidated = async context =>  
            {
                logger.LogInformation("Token validated successfully");

                var transformation = context.HttpContext.RequestServices
                    .GetRequiredService<IClaimsTransformation>();

                if (context.Principal?.Identity?.IsAuthenticated == true)
                {
                    context.Principal = await transformation.TransformAsync(context.Principal);
                    logger.LogInformation("Claims transformation completed");
                }
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
