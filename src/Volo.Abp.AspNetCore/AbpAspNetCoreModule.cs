using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.AspNetCore.Modularity;
using Volo.Abp.DependencyInjection.DependencyInjection;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore;

public class AbpAspNetCoreModule : IAbpModule
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAssemblyOf<AbpAspNetCoreModule>();
        services.AddSingleton<IModuleInitializer, AspNetCoreModuleInitializer>();
    }
}