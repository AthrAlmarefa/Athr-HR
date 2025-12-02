using Asp.Versioning;
using Dapper;
using Athr.Application.Abstractions.Clock;
using Athr.Application.Abstractions.DataFactory;
using Athr.Application.Abstractions.Email;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.BusinessRoles;
using Athr.Domain.Categories;
using Athr.Domain.Qualification;
using Athr.Domain.Users;
using Athr.Infrastructure.Clock;
using Athr.Infrastructure.Data;
using Athr.Infrastructure.Email;
using Athr.Infrastructure.Interceptors;
using Athr.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ArgumentNullException = System.ArgumentNullException;
using Athr.Application.Abstractions.Authentication;
using Athr.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Athr.Infrastructure.Authorization;
using Athr.Application.Abstractions.Caching;
using Athr.Infrastructure.Caching;
using StackExchange.Redis;

namespace Athr.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        AddPersistence(services, configuration);
        AddCaching(services, configuration);
        AddHealthChecks(services, configuration);

        AddApiVersioning(services);
        AddAuthentication(services, configuration);
    }

    private static void AddPersistence(
        IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database") ??
                                  throw new ArgumentNullException(nameof(configuration));

        bool logSensitiveData = configuration.GetValue<bool>("Logs:LogSensitiveData");

        services.AddScoped<SoftDeletionInterceptor>();
        
        services.AddScoped<AuditingInterceptor>();
        services.AddScoped<TrackingInterceptor>();

        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            })
            .EnableSensitiveDataLogging(logSensitiveData)
            .UseSnakeCaseNamingConvention()
            .AddInterceptors(
                serviceProvider.GetRequiredService<AuditingInterceptor>(),
                serviceProvider.GetRequiredService<SoftDeletionInterceptor>(),
                serviceProvider.GetRequiredService<TrackingInterceptor>()
            ));

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IBusinessRoleRepository, BusinessRoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IQualificationRepository, QualificationRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        services.AddScoped<AuthorizationService>();
    }
    private static void AddCaching(IServiceCollection services, IConfiguration configuration)
    {
        var cacheConnectionString = configuration.GetConnectionString("Cache");

        try
        {
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var configOptions = ConfigurationOptions.Parse(cacheConnectionString);
                configOptions.AbortOnConnectFail = false;
                configOptions.ReconnectRetryPolicy = new ExponentialRetry(5000);
                configOptions.ConnectTimeout = 5000;
                configOptions.SyncTimeout = 5000;

                return ConnectionMultiplexer.Connect(configOptions);
            });

            services.AddSingleton<ICacheService, RedisCacheService>();

            Console.WriteLine("Redis cache configured successfully");
        }
        catch (Exception ex)
        {
            // Fallback to Memory Cache
            Console.WriteLine($"Redis failed: {ex.Message}, falling back to Memory Cache");
        }
    }

    private static void AddHealthChecks(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("Database")!);
    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        // ⭐⭐⭐ استخدم JwtOptions section ⭐⭐⭐
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IClaimsTransformation, CustomClaimsTransformation>();
        services.AddScoped<Application.Abstractions.Authentication.IAuthenticationService,
            Athr.Infrastructure.Authentication.AuthenticationService>();

        // ⭐⭐⭐ جيب الـ JwtOptions ⭐⭐⭐
        var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>()
            ?? throw new InvalidOperationException("JwtOptions configuration is missing");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer, // ⭐⭐⭐ من JwtOptions ⭐⭐⭐
                    ValidAudience = jwtOptions.Audience, // ⭐⭐⭐ من JwtOptions ⭐⭐⭐
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.SecretKey)), // ⭐⭐⭐ من JwtOptions ⭐⭐⭐
                    ClockSkew = TimeSpan.Zero
                };

                // ⭐⭐⭐ Claims Transformation Events ⭐⭐⭐
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var transformation = context.HttpContext.RequestServices
                            .GetRequiredService<IClaimsTransformation>();

                        if (context.Principal?.Identity?.IsAuthenticated == true)
                        {
                            context.Principal = await transformation.TransformAsync(context.Principal);
                        }
                    }
                };
            });
    }

    private static void AddApiVersioning(IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        }).AddMvc().AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });
    }
}
