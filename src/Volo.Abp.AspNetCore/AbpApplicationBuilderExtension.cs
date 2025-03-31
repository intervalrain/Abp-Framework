using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.Abp;
using Volo.Abp.DependencyInjection.DependencyInjection;

namespace Volo.Abp.AspNetCore;

public static class AbpApplicationBuilderExtension
{
    public static void InitializeApplication(this IApplicationBuilder app)
    {
        app.ApplicationServices.GetRequiredService<ObjectAccessor<IApplicationBuilder>>().Object = app;
        app.ApplicationServices.GetRequiredService<AbpApplication>().Initialize(app.ApplicationServices);
    }
}

public class ApplicationBuilderAccessor : ISingletonDependency
{
    public IApplicationBuilder? App { get; set; }
}