namespace Athr.Api;

public sealed class CorsOptions
{
    public string AllowedOrigins { get; set; } 
    public string AllowedMethods { get; set; } 
    public string AllowedHeaders { get; set; } 
    public int PreflightMaxAgeMinutes { get; set; } = 10;
}
