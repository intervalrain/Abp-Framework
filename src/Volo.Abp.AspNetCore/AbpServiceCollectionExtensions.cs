using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.Abp;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore;

public static class AbpServiceCollectionExtensions
{
    public static AbpApplication AddApplication<TStartupModule>(this IServiceCollection services)
        where TStartupModule : IAbpModule
    {
        return AbpApplication.Create<TStartupModule>(services);
    }
}