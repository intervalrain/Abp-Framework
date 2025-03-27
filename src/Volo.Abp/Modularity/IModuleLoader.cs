using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.DependencyInjection.DependencyInjection;

namespace Volo.Abp.Modularity;

public interface IModuleLoader : ISingletonDependency
{
    IReadOnlyList<AbpModuleDescriptor> Modules { get; }

    void LoadAll(IServiceCollection services, Type startupModuleType);
}