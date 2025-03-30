using System.Collections.Immutable;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Abp;
using Volo.ExtensionMethods.Collections.Generic;

namespace Volo.Abp.Modularity;

public class ModuleLoader : IModuleLoader
{
    public IReadOnlyList<AbpModuleDescriptor> Modules => _modules.ToImmutableList();
    private readonly List<AbpModuleDescriptor> _modules = [];

    public virtual void LoadAll(IServiceCollection services, Type startupModuleType)
    {
        if (_modules.Count > 0)
        {
            throw new InvalidOperationException($"{nameof(LoadAll)} should be called only once!");
        }

        FillModules(services, startupModuleType);
        SetModuleDependencies();
        SortByDependency(startupModuleType);
        ConfigureServices(services);
    }

    private void SetModuleDependencies()
    {
        Modules.ForEach(SetModuleDependencies);
    }

    private void SortByDependency(Type startupModuleType)
    {
        _modules.SortByDependencies(m => m.Dependencies);
        _modules.MoveItem(m => m.Type == typeof(AbpKernelModule), 0);
        _modules.MoveItem(m => m.Type == startupModuleType, _modules.Count - 1);
    }


    private void FillModules(IServiceCollection services, Type startupModuleType)
    {
        FindAllModuleTypes(startupModuleType).Distinct().ForEach(type => _modules.Add(CreateModuleDescriptor(services, type)));
    }

    protected virtual IEnumerable<Type> FindAllModuleTypes(Type startupModuleType)
    {
        var types = new List<Type>();
        AddModuleAndDependenciesRecursively(types, startupModuleType);
        types.AddIfNotContains(typeof(AbpKernelModule));
        return types;
    }

    protected virtual AbpModuleDescriptor CreateModuleDescriptor(IServiceCollection services, Type moduleType)
    {
        return new AbpModuleDescriptor(moduleType, CreateAndRegisterModule(services, moduleType));
    }

    private IAbpModule CreateAndRegisterModule(IServiceCollection services, Type moduleType)
    {
        var module = (IAbpModule)Activator.CreateInstance(moduleType)!;
        services.AddSingleton(moduleType, module);
        
        return module;
    }


    private void ConfigureServices(IServiceCollection services)
    {
        _modules.ForEach(module => module.Instance.ConfigureServices(services));
    }

    protected virtual void AddModuleAndDependenciesRecursively(List<Type> moduleTypes, Type moduleType)
    {
        CheckAbpModuleType(moduleType);

        if (moduleTypes.Contains(moduleType))
        {
            return;
        }

        moduleTypes.Add(moduleType);

        FindDependedModuleTypes(moduleType).ForEach(type => AddModuleAndDependenciesRecursively(moduleTypes, type));
    }

    protected virtual List<Type> FindDependedModuleTypes(Type moduleType)
    {
        CheckAbpModuleType(moduleType);

        var dependencies = new List<Type>();

        var dependencyDescriptors = moduleType
            .GetCustomAttributes()
            .OfType<IDependedModuleTypesProvider>();

        foreach (var descriptor in dependencyDescriptors) foreach (var dependedModuleType in descriptor.GetDependedModuleTypes())
        {
            dependencies.AddIfNotContains(dependedModuleType);
        }

        return dependencies;
    }

    protected virtual void SetModuleDependencies(AbpModuleDescriptor module)
    {
        foreach (var dependedModuleType in FindDependedModuleTypes(module.Type))
        {
            var dependencies = _modules.FirstOrDefault(m => m.Type == dependedModuleType)
                ?? throw new AbpException("Could not find a depended module " + dependedModuleType.AssemblyQualifiedName + " for " + module.Type.AssemblyQualifiedName);
            
            module.Dependencies.AddIfNotContains(dependencies);
        }
    }

    protected static void CheckAbpModuleType(Type moduleType)
    {
        if (!IsAbpMoudle(moduleType))
        {
            throw new ArgumentException("Given type is not an ABP module: " + moduleType.AssemblyQualifiedName);
        }
    }

    protected static bool IsAbpMoudle(Type type)
    {
        return type.IsClass && !type.IsAbstract && !type.IsGenericType && typeof(IAbpModule).IsAssignableFrom(type);
    }
}