using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Tests.Modularity;

namespace Volo.Abp.Tests;

public class AbpApplication_Tests
{
    [Fact]
    public void Should_Start_And_Stop_Empty_AbpApplication()
    {
        var services = new ServiceCollection();

        using var application = AbpApplication.Create<IndependentEmptyModule>(services);
        
        application.Start(services.BuildServiceProvider());
    }
}