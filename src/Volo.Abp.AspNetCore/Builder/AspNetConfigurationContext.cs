using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Volo.Abp.AspNetCore.Builder;

public class AspNetConfigurationContext(IApplicationBuilder app)
{
    public IApplicationBuilder App { get; } = app;
    public IHostingEnvironment Environment { get; } = app.ApplicationServices.GetRequiredService<IHostingEnvironment>();
    // public ILoggerFactory LoggerFactory { get; } = app.ApplicationServices.GetRequiredService<ILoggerFactory>();
}