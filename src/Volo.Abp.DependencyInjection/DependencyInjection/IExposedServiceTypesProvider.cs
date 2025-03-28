namespace Volo.Abp.DependencyInjection.DependencyInjection;

public interface IExposedServiceTypesProvider
{
    Type[] GetExposedServiceTypes();
}