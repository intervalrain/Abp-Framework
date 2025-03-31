namespace Volo.Abp.DependencyInjection.DependencyInjection;

public interface IObjectAccessor<T>
{
    T Object { get; }
}