using JetBrains.Annotations;

namespace Volo.Abp.MultiTenancy;

public class AmbientTenantInfo([CanBeNull] TenantInfo? tenant)
{
    public TenantInfo? Tenant { get; } = tenant;
}