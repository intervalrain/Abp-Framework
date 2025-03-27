namespace Volo.Abp.Abp;

public interface IAbpApplication : IDisposable
{
    Type StartupModuleType { get; }
    void Initialize(IServiceProvider serviceProvider);
}