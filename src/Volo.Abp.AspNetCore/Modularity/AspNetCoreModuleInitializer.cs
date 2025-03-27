using Volo.Abp.AspNetCore.Builder;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore.Modularity;

public class AspNetCoreModuleInitializer(ApplicationBuilderAccessor appAccessor) : IModuleInitializer
{
    private readonly AspNetConfigurationContext _configurationContext = new AspNetConfigurationContext(appAccessor.App!);

    public void Initialize(IAbpModule module)
    {
        (module as IConfigureAspNet)?.Configure(_configurationContext);
    }
}