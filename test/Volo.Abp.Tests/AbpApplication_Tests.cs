using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.Abp;
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
        
        application.Initialize(services.BuildServiceProvider());
    }
}