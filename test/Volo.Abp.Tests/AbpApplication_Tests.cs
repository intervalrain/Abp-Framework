using Microsoft.Extensions.DependencyInjection;

using Shouldly;

using Volo.Abp.Abp;
using Volo.Abp.Tests.Modularity;

namespace Volo.Abp.Tests;

public class AbpApplication_Tests
{
    [Fact]
    public void Should_Initialize_SingleModule_Application()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        using var application = AbpApplication.Create<IndependentEmptyModule>(services);
        application.Initialize(services.BuildServiceProvider());

        // Assert
        var module = application.ServiceProvider?.GetRequiredService<IndependentEmptyModule>();
        module?.ConfigureServicesIsCalled.ShouldBeTrue();
        module?.OnApplicationInitializeIsCalled.ShouldBeTrue();
    }
}