using Microsoft.Extensions.DependencyInjection;

namespace Volo.Abp.DependencyInjection.DependencyInjection;

public static class CommonServiceCollectionExtensions
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

    public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services)
    {
        return services.AddObjectAccessor(new ObjectAccessor<T>());
    }

    public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services, T obj)
    {
        return services.AddObjectAccessor(new ObjectAccessor<T>(obj));
    }

    public static ObjectAccessor<T> AddObjectAccessor<T>(this IServiceCollection services, ObjectAccessor<T> accessor)
    {
        services.AddSingleton(typeof(IObjectAccessor<T>), accessor);
        services.AddSingleton(typeof(ObjectAccessor<T>), accessor);

        return accessor;
    }
}