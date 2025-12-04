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
using Dapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;

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

    }

    private static void AddHealthChecks(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("Database")!);
    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IUserContext, UserContext>();
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
