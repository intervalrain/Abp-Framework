using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection.Internal;

namespace Volo.Abp.DependencyInjection.DependencyInjection;

public static class AbpConventionalDependencyInjection
{
    public static void AddAssembly(this IServiceCollection services, Assembly assembly)
    {
        services.AddTypes(AssemblyHelper.GetAllTypes(assembly).FilterInjectableTypes().ToArray());
    }

    public static void AddTypes(this IServiceCollection services, params Type[] types)
    {
        foreach (var type in types)
        {
            services.AddType(type);
        }
    }

    public static void AddType(this IServiceCollection services, Type type)
    {
        if (typeof(ITransientDependency).IsAssignableFrom(type))
        {
            services.AddTransient(type);
        }

        if (typeof(ISingletonDependency).IsAssignableFrom(type))
        {
            services.AddSingleton(type);
        }
    }

    private static IEnumerable<Type> FilterInjectableTypes(this IEnumerable<Type> types)
    {
        return types.Where(type => 
        {
            return type.IsClass && !type.IsAbstract && !type.IsGenericType;
        });
    }
}