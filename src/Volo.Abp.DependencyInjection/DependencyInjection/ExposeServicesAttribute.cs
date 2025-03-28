namespace Volo.Abp.DependencyInjection.DependencyInjection;

[AttributeUsage(AttributeTargets.Class)]
public class ExposeServicesAttribute(params Type[] exposedServiceTypes) : Attribute, IExposedServiceTypesProvider
{
    public Type[] ExposedServiceTypes { get; } = exposedServiceTypes;

    public Type[] GetExposedServiceTypes() => ExposedServiceTypes;
}