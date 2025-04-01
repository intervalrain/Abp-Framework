
using Volo.Abp.Abp;

namespace Volo.Abp.MultiTenancy;

public class MultiTenancyManager(IAmbientTenantAccessor ambientTenantAccessor, IEnumerable<ITenantResolver> currentTenantResolvers)
    : IMultiTenantManager
{
    public TenantInfo? CurrentTenant => GetCurrentTenant();

    private readonly IAmbientTenantAccessor _ambientTenantAccessor = ambientTenantAccessor;
    private readonly IEnumerable<ITenantResolver> _currentTenantResolvers = currentTenantResolvers;   

    protected virtual TenantInfo? GetCurrentTenant()
    {
        if (_ambientTenantAccessor.AmbientTenant != null)
        {
            return _ambientTenantAccessor.AmbientTenant.Tenant;
        }
        
        var context = new CurrentTenantResolveContext();

        foreach (var currentTenantResolver in _currentTenantResolvers)
        {
            currentTenantResolver.Resolve(context);
            if (context.Handled)
            {
                break;
            }
        }

        return context.Tenant;
    }

    public IDisposable ChangeTenant(TenantInfo tenantInfo)
    {
        var oldValue = _ambientTenantAccessor.AmbientTenant;

        _ambientTenantAccessor.AmbientTenant = new AmbientTenantInfo(tenantInfo);

        return new DisposeAction(() => _ambientTenantAccessor.AmbientTenant = oldValue);
    }

}