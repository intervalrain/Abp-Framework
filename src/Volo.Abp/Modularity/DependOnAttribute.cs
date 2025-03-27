namespace Volo.Abp.Modularity;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class DependOnAttribute(params Type[] dependedModuleTypes) : Attribute, IModuleDependencyDescriptor
{
    public Type[] DependedModuleTypes { get; } = dependedModuleTypes;

    public Type[] GetDependedModuleTypes()
    {
        return DependedModuleTypes;
    }
}