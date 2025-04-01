namespace Volo.Abp.MultiTenancy;

public class MultiTenancyManager(IEnumerable<ITenantResolver> currentTenantResolvers) : IMultiTenantManager
{
    public ITenantInfo CurrentTenant => GetCurrentTenant();
    
    private readonly IEnumerable<ITenantResolver> _currentTenantResolvers = currentTenantResolvers;   

    protected virtual ITenantInfo GetCurrentTenant()
    {
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
}