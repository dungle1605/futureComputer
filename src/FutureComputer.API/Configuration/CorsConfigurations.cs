namespace FutureComputer.API.Configuration;

public static class CorsConfigurations
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(opts =>
            opts.AddDefaultPolicy(builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .WithExposedHeaders("*")));
    }
}