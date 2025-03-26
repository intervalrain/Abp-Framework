using System.Reflection;

namespace Volo.Abp.DependencyInjection.Internal;

internal static class AssemblyHelper
{
    public static IReadOnlyList<Type> GetAllTypes(Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException ex)
        {
            return ex.Types;
        }
    }
}