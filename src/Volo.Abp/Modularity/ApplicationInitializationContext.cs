namespace Volo.Abp.Modularity;

public class ApplicationInitializationContext(IServiceProvider serviceProvider)
{
    public IServiceProvider ServiceProvider { get; set; } = serviceProvider;
}