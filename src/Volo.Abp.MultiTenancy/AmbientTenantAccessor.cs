using Volo.Abp.DependencyInjection.DependencyInjection;

namespace Volo.Abp.MultiTenancy;

public class AmbientTenantAccessor : IAmbientTenantAccessor, ISingletonDependency
{
    private readonly AsyncLocal<AmbientTenantInfo> _tenant = new();

    public AmbientTenantInfo? AmbientTenant 
    { 
        get => _tenant.Value;
        set => _tenant.Value = value ?? throw new Exception();
    }
}