using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection.DependencyInjection;

namespace Volo.Abp.Modularity;

public interface IAbpModule : ISingletonDependency
{
    void ConfigureServices(IServiceCollection services);
}