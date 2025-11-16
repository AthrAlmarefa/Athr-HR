using HealthChecks.UI.Client;
using Athr.Api.Extensions;
using Athr.Api.OpenApi;
using Athr.Application;
using Athr.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Serilog;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.ValidateEnvironment();

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.AddSwaggerGenInternal();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.AddCors();

builder.AddLocalStorageRoot();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("RemoteDevelopment"))
{
    app.Use(async (context, next) =>
    {

        // Print headers to the console
        foreach (KeyValuePair<string, StringValues> header in context.Request.Headers)
        {
            Console.WriteLine($"{header.Key}: {header.Value}");
        }

        // Call the next middleware in the pipeline
        await next();
    });

    app.UseSwaggerInternal();

    app.ApplyMigrations();

    builder.Configuration.PrintAllConfigurations();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseCustomExceptionHandler();

app.UseDocumentsStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("health",
    new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });

Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

await app.RunAsync();
