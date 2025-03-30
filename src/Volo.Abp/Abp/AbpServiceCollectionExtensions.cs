using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Volo.Abp.Modularity;

namespace Volo.Abp.Abp;

public static class AbpServiceCollectionExtensions
{
    public static T? GetSingletonInstanceOrNull<T>(this IServiceCollection services)
    {
        return (T?)services
            .FirstOrDefault(d => d.ServiceType == typeof(T))
            ?.ImplementationInstance;
    }

    public static T GetSingletonInstance<T>(this IServiceCollection services)
    {
        return services.GetSingletonInstanceOrNull<T>() ?? throw new InvalidOperationException("Could not find singleton services: " + typeof(T).AssemblyQualifiedName);
    }

    internal static void AddCoreAbpServices(this IServiceCollection services)
    {
        services.TryAddSingleton<IModuleLoader>(new ModuleLoader());
    }
}