namespace Volo.Abp.MultiTenancy;

public interface IMultiTenantManager
{
    TenantInfo? CurrentTenant { get; }
    
    IDisposable ChangeTenant(TenantInfo tenantInfo);
}