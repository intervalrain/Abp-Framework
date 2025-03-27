using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.Abp;
using Volo.Abp.DependencyInjection.DependencyInjection;

namespace Volo.Abp.AspNetCore;

public static class AbpApplicationBuilderExtension
{
    public static void InitializeAbpApplication(this IApplicationBuilder app)
    {
        var abpApplication = app.ApplicationServices.GetRequiredService<IAbpApplication>();

        app.ApplicationServices.GetRequiredService<ApplicationBuilderAccessor>().App = app;

        abpApplication.Initialize(app.ApplicationServices);
    }
}

public class ApplicationBuilderAccessor : ISingletonDependency
{
    public IApplicationBuilder? App { get; set; }
}