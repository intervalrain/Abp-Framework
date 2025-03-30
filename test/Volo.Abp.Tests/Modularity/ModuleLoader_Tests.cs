using Microsoft.Extensions.DependencyInjection;

using Shouldly;

using Volo.Abp.Abp;

using Volo.Abp.Modularity;

namespace Volo.Abp.Tests.Modularity;

public class ModuleLoader_Tests
{
    [Fact]
    public void Should_Load_Modulers_By_Dependency_Order()
    {
        var moduleLoader = new ModuleLoader();
        moduleLoader.LoadAll(new ServiceCollection(), typeof(MyStartupModule));
        moduleLoader.Modules.Count.ShouldBe(3);
        moduleLoader.Modules[0].Type.ShouldBe(typeof(AbpKernelModule));
        moduleLoader.Modules[1].Type.ShouldBe(typeof(IndependentEmptyModule));
        moduleLoader.Modules[2].Type.ShouldBe(typeof(MyStartupModule));
    }
}

[DependOn(typeof(IndependentEmptyModule))]
public class MyStartupModule : IAbpModule
{
    public void ConfigureServices(IServiceCollection services)
    {
    }
}