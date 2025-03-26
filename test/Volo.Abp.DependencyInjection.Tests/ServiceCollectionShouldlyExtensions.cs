using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Volo.Abp.DependencyInjection.Tests;

public static class ServiceCollectionShouldlyExtensions
{
    public static void ShouldContainTransient(this IServiceCollection services, Type type)
    {
        var serivceDescriptor = services.FirstOrDefault(s => s.ServiceType == type)!;

        serivceDescriptor.ImplementationType.ShouldBe(type);
        serivceDescriptor.ShouldNotBeNull();
        serivceDescriptor.ImplementationFactory.ShouldBeNull();
        serivceDescriptor.ImplementationInstance.ShouldBeNull();
        serivceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
    }

    public static void ShouldContainSingleton(this IServiceCollection services, Type type)
    {
        var serivceDescriptor = services.FirstOrDefault(s => s.ServiceType == type);

        serivceDescriptor.ImplementationType.ShouldBe(type);
        serivceDescriptor.ShouldNotBeNull();
        serivceDescriptor.ImplementationFactory.ShouldBeNull();
        serivceDescriptor.ImplementationInstance.ShouldBeNull();
        serivceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Singleton);
    }
}