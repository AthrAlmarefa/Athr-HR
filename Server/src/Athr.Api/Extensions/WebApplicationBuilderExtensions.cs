using Asp.Versioning.ApiExplorer;
using Athr.Api.Extensions;
using Athr.Api.Swagger;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Client.Extensions.Msal;

using static Athr.Domain.BuildingBlocks.Constants;

namespace Athr.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    private const string Development = "Development";
    private const string RemoteDevelopment = "RemoteDevelopment";
    private const string Staging = "Staging";
    private const string Production = "Production";

    public static void AddCors(this WebApplicationBuilder builder)
    {
        CorsOptions? corsSettings = builder.Configuration.GetSection("Cors").Get<CorsOptions>() ??
                                    throw new InvalidOperationException("CORS settings are missing in configuration.");

        string[] allowedOrigins =
            corsSettings.AllowedOrigins?.Split(',',
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries) ?? [];
        string[] allowedMethods =
            corsSettings.AllowedMethods?.Split(',',
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries) ?? [];
        string[] allowedHeaders =
            corsSettings.AllowedHeaders?.Split(',',
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries) ?? [];

        string environment = builder.Environment.EnvironmentName;
        Console.WriteLine($"Environment: {environment}");

        Console.WriteLine("Allowed Origins: " + string.Join(", ", corsSettings.AllowedOrigins));

        builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
        {
            if (allowedOrigins is ["*"])
            {
                policy.AllowAnyOrigin();
            }
            else
            {
                policy.WithOrigins(allowedOrigins);
            }

            if (allowedMethods is ["*"])
            {
                policy.AllowAnyMethod();
            }
            else
            {
                policy.WithMethods(allowedMethods);
            }

            if (allowedHeaders is ["*"])
            {
                policy.AllowAnyHeader();
            }
            else
            {
                policy.WithHeaders(allowedHeaders);
            }

            policy.SetPreflightMaxAge(TimeSpan.FromMinutes(corsSettings.PreflightMaxAgeMinutes));
        }));
    }


    public static void AddSwaggerGenInternal(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SupportNonNullableReferenceTypes();
            c.SchemaFilter<RequiredNotNullableSchemaFilter>();
            c.OperationFilter<OperationIdFilter>();
        });
    }

    public static void UseSwaggerInternal(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (ApiVersionDescription description in app.DescribeApiVersions())
            {
                string url = $"/swagger/{description.GroupName}/swagger.json";
                string name = description.GroupName.ToUpperInvariant();
                options.SwaggerEndpoint(url, name);
            }
        });
    }

    public static void ValidateEnvironment(this WebApplicationBuilder builder)
    {
        string[] validEnvironments = [Development, RemoteDevelopment, Staging, Production];
        string environment = builder.Environment.EnvironmentName;

        if (!validEnvironments.Contains(environment))
        {
            throw new InvalidOperationException(
                $"Invalid environment: '{environment}'. Expected one of: {string.Join(", ", validEnvironments)}."
            );
        }
    }

    public static void PrintAllConfigurations(this IConfiguration config)
    {
#pragma warning disable CA1303
        Console.WriteLine("All Configurations:");
#pragma warning restore CA1303
        foreach (KeyValuePair<string, string?> pair in config.AsEnumerable())
        {
            Console.WriteLine($"{pair.Key} = {pair.Value}");
        }
    }

    public static void AddLocalStorageRoot(this WebApplicationBuilder builder)
    {
        /*??????????  LOCAL STORAGE ROOT  ??????????*/
        // 1??  Absolute path on disk
        string documentsDir = Path.Combine(builder.Environment.ContentRootPath, PublicPath);
        //string uploadsDir = Path.Combine(documentsDir, "uploads");
        if (!Path.Exists(documentsDir) )
        // 2??  Ensure both directories exist
        Directory.CreateDirectory(documentsDir);
    }

    public static void UseDocumentsStaticFiles(this WebApplication app)
    {
        var physicalPath = Path.Combine(app.Environment.ContentRootPath, PublicPath);
        const int cacheSeconds = 60 * 60 * 24 * 7;
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(physicalPath),
            RequestPath = $"/{PublicPath}",
            OnPrepareResponse = ctx =>
            {
                ctx.Context.Response.Headers["Cache-Control"] = $"public,max-age={cacheSeconds}";
            }
        });
    }
}
