namespace Volo.Abp.MultiTenancy;

public interface ICurrentTenantResolver
{
    void Resolve(ICurrentTenantResolveContext context);
}