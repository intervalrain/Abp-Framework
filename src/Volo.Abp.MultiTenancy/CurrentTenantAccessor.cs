namespace Volo.Abp.MultiTenancy;

public class CurrentTenantAccessor(IEnumerable<ICurrentTenantResolver> currentTenantResolvers) : ICurrentTenantAccessor
{
    public Guid Id => GetTenantId();

    public string Name { get; }

    private readonly IEnumerable<ICurrentTenantResolver> _currentTenantResolvers = currentTenantResolvers;   

    public virtual Guid GetTenantId()
    {
        throw new NotImplementedException();
    }
}