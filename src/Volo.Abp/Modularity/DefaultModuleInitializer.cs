namespace Volo.Abp.Modularity;

public class DefaultModuleInitializer(IServiceProvider serviceProvider) : IModuleInitializer
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public void Initialize(IAbpModule module)
    {
        var context = new ApplicationInitializationContext(_serviceProvider);
        (module as IOnApplicationInitialization)?.OnApplicationInitialization(context);
    }
}