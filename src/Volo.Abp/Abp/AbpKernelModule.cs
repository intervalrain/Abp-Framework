using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.DependencyInjection.DependencyInjection;
using Volo.Abp.Modularity;

namespace Volo.Abp.Abp;

public class AbpKernelModule : AbpModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddAssemblyOf<AbpKernelModule>();
    }
}