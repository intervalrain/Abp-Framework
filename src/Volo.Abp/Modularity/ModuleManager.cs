using Volo.Abp.DependencyInjection.DependencyInjection;

namespace Volo.Abp.Modularity;

public class ModuleManager(IModuleLoader moduleLoader, IEnumerable<IModuleInitializer> initializers) : IModuleManager, ISingletonDependency
{
    private readonly IModuleLoader _moduleLoader = moduleLoader;
    private readonly IEnumerable<IModuleInitializer> _initializers = initializers;

    public void Initialize()
    {
        foreach (var initialier in _initializers) foreach (var module in _moduleLoader.Modules)
        {
            initialier.Initialize(module.Instance);
        }
    }

}