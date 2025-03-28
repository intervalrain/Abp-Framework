using System.Data;
using System.Reflection;


using Microsoft.Extensions.DependencyInjection;


using Volo.Abp.DependencyInjection.Internal;

namespace Volo.Abp.DependencyInjection.DependencyInjection;

public static class AbpConventionalDependencyInjection
{
    public static void AddAssemblyOf<T>(this IServiceCollection services)
    {
        services.AddAssembly(typeof(T).Assembly);
    }

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
        foreach (var serviceType in FindServiceTypes(type))
        {
            if (typeof(ITransientDependency).IsAssignableFrom(type))
            {
                services.AddTransient(serviceType, type);
            }

            if (typeof(ISingletonDependency).IsAssignableFrom(type))
            {
                services.AddSingleton(serviceType, type);
            }

            if (typeof(IScopedDependency).IsAssignableFrom(type))
            {
                services.AddScoped(serviceType, type);
            }
        }
    }

    private static List<Type> FindServiceTypes(Type type)
    {
        var customExposedServices = type.GetCustomAttributes()
            .OfType<IExposedServiceTypesProvider>()
            .SelectMany(p => p.GetExposedServiceTypes()).ToList();

        if (customExposedServices.Any())
        {
            return customExposedServices;
        }


        List<Type> serviceTypes = [type];

        foreach (var interfaceType in type.GetInterfaces())
        {
            var interfaceName = interfaceType.Name;
            if (interfaceName.StartsWith('I'))
            {
                interfaceName = interfaceName.Substring(1);
            }
            if (type.Name.EndsWith(interfaceName))
            {
                serviceTypes.Add(interfaceType);
            }
        }

        return serviceTypes;
    }

    private static IEnumerable<Type> FilterInjectableTypes(this IEnumerable<Type> types)
    {
        return types.Where(type => 
        {
            return type.IsClass && !type.IsAbstract && !type.IsGenericType;
        });
    }
}