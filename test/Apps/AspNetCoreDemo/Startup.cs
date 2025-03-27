using Volo.Abp.AspNetCore;

namespace AspNetCoreDemo;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAbpApplication<AppModule>();
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env, ILoggerFactory loggerFactory)
    {
        app.InitializeAbpApplication();
    }
}