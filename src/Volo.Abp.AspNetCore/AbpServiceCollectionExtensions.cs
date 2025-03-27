using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.Abp;

using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore;

public static class AbpServiceCollectionExtensions
{
    public static void AddAbpApplication<TStartupModule>(this IServiceCollection services)
        where TStartupModule : IAbpModule
    {
        AbpApplication.Create<TStartupModule>(services);
    }
}