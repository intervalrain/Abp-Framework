namespace Volo.Abp.MultiTenancy;

public interface IAmbientTenantAccessor
{
    AmbientTenantInfo? AmbientTenant { get; set; }
}