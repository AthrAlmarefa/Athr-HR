using Athr.Api.Middleware;
using Athr.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Athr.Api.Extensions;

internal static class ApplicationBuilderExtensions
{
    public static async void ApplyMigrations(this IApplicationBuilder applicationBuilder)
    {
        using IServiceScope scope = applicationBuilder.ApplicationServices.CreateScope();
        using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        try
        {
            var x = dbContext.Database.GetConnectionString();
            dbContext.Database.Migrate();
            await SeedingBasicData.SeedDataAsync(dbContext);
        }
        catch (Exception ex)
        {
            ILogger logger = applicationBuilder.ApplicationServices.GetRequiredService<ILogger<ApplicationDbContext>>();
            logger.LogError(
                ex,
                "An error occured During Migration");
        }
    }

    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }

    public static IApplicationBuilder UseRequestContextLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestContextLoggingMiddleware>();

        return app;
    }
}
