using Asp.Versioning;
using Dapper;
using Athr.Application.Abstractions.Authentication;
using Athr.Application.Abstractions.Caching;
using Athr.Application.Abstractions.Clock;
using Athr.Application.Abstractions.DataFactory;
using Athr.Application.Abstractions.Email;
using Athr.Application.Common;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.BusinessRoles;
using Athr.Domain.Categories;
using Athr.Domain.Countries;
using Athr.Domain.Qualification;
using Athr.Domain.Users;
using Athr.Infrastructure.Authentication;
using Athr.Infrastructure.Authorization;
using Athr.Infrastructure.Caching;
using Athr.Infrastructure.Clock;
using Athr.Infrastructure.Data;
using Athr.Infrastructure.Email;
using Athr.Infrastructure.Interceptors;
using Athr.Infrastructure.Outbox;
using Athr.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Globalization;
using ArgumentNullException = System.ArgumentNullException;
using AuthenticationOptions = Athr.Infrastructure.Authentication.AuthenticationOptions;

namespace Athr.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        services.AddScoped<IFileStorageService, FileStorageService>();

        AddPersistence(services, configuration);

        AddCaching(services, configuration);

        AddAuthentication(services, configuration);

        AddAuthorization(services);

        AddHealthChecks(services, configuration);

        AddApiVersioning(services);

        AddBackgroundJobs(services, configuration);
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
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IQualificationRepository, QualificationRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

    }

    private static void AddHealthChecks(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("Database")!);
    }

    private static void AddCaching(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Cache") ??
                                  throw new ArgumentNullException(nameof(configuration));

        services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);

        services.AddSingleton<ICacheService, CacheService>();
    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer();

        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddHttpContextAccessor();

        services.AddScoped<IUserContext, UserContext>();

        services.AddScoped<IJwtService, JwtService>();

        //services.AddHttpClient<IJwtService, JwtService>((serviceProvider, httpClient) =>
        //{
        //    KeycloakOptions keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeycloakOptions>>().Value;

        //    httpClient.BaseAddress = new Uri(keycloakOptions.TokenUrl);
        //});
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

    private static void AddAuthorization(IServiceCollection services)
    {
        services.AddScoped<AuthorizationService>();

        services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();

        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();

        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
    }

    private static void AddBackgroundJobs(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OutboxOptions>(configuration.GetSection("Outbox"));
        services.Configure<JobExpressions>(configuration.GetSection("JobExpressions"));

        string uniqueId = CreateSchedulerUniqueId(services);
        services.AddQuartz(configurator => configurator.SchedulerName = uniqueId);

        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        services.ConfigureOptions<ProcessOutboxMessagesJobSetup>();
    }

    private static string CreateSchedulerUniqueId(IServiceCollection services)
    {
        int hashCode = Guid.NewGuid().ToString().GetHashCode();
        string uniqueId = hashCode.ToString("x", CultureInfo.InvariantCulture);
        IWebHostEnvironment environment = services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();
        return $"{environment.ApplicationName}-{uniqueId}";
    }
}
