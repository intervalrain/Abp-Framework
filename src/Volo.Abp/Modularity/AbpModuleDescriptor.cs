using System.Diagnostics.CodeAnalysis;

using Volo.CodeAnnotations;

namespace Volo.Abp.Modularity;

public class AbpModuleDescriptor
{
    public Type Type { get; }
    public IAbpModule Instance { get; }
    public List<AbpModuleDescriptor> Dependencies { get; } = [];

    public AbpModuleDescriptor([NotNull] Type type, [NotNull] IAbpModule instance)
    {
        Check.NotNull(type, nameof(type));
        Check.NotNull(instance, nameof(instance));

        Type = type;
        Instance = instance;
    }
}