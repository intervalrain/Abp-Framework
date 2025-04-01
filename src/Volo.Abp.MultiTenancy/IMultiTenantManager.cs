namespace Volo.Abp.MultiTenancy;

public interface IMultiTenantManager
{
    ITenantInfo CurrentTenant { get; }
}