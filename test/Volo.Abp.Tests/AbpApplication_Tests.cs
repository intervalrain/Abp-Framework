using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.DependencyInjection.Tests;
using Volo.Abp.Tests.Modularity;

namespace Volo.Abp.Tests;

public class AbpApplication_Tests
{
    [Fact]
    public void Should_Start_And_Stop_Empty_Application()
    {
        var services = new ServiceCollection();

        using var application = AbpApplication.Create<IndependentEmptyModule>(services);
        
        application.Start(services.BuildServiceProvider());
    }

    [Fact]
    public void Should_Automatically_Register_Modules()
    {
        var services = new ServiceCollection();

        using var application = AbpApplication.Create<IndependentEmptyModule>(services);
        
        services.ShouldContainSingleton(typeof(IndependentEmptyModule));
    }
}