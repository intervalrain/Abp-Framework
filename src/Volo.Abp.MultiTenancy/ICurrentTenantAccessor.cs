namespace Volo.Abp.MultiTenancy;

public interface ICurrentTenantAccessor
{
    Guid Id { get; }
    string Name { get; }
}