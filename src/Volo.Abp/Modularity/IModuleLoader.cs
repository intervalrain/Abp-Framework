using Microsoft.Extensions.DependencyInjection;

namespace Volo.Abp.Modularity;

public interface IModuleLoader
{
    IReadOnlyList<AbpModuleDescriptor> Modules { get; }

    void LoadAll(IServiceCollection services, Type startupModuleType);
}