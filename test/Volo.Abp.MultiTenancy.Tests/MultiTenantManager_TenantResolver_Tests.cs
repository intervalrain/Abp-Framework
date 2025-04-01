using System.Buffers;
using System.Reflection.Metadata;

using NSubstitute;

using Shouldly;

namespace Volo.Abp.MultiTenancy.Tests;

public class MultiTenantManager_TenantResolver_Tests
{
    [Fact]
    public void Should_Get_Current_Tenant_As_Null_If_No_Resolver()
    {
        // Arrange
        var manager = new MultiTenancyManager(Substitute.For<IAmbientTenantAccessor>(), []);

        // Act
        manager.CurrentTenant.ShouldBeNull();
    }

    [Fact]
    public void Should_Get_Current_Tenant_From_Single_Resolver()
    {
        // Arrange
        var fakeTenant = new TenantInfo(Guid.NewGuid().ToString(), "test");

        // Act
        var manager = new MultiTenancyManager(Substitute.For<IAmbientTenantAccessor>(),
            [
                new TenantResolverAction(context => 
                {
                    context.Tenant = fakeTenant;
                    context.Handled = true;
                })
            ]);
        
        // Assert
        manager.CurrentTenant.ShouldBe(fakeTenant);
    }

    [Fact]
    public void Should_Get_Current_Tenant_From_Two_Resolvers()
    {
        // Arrange
        var emptyTenant1 = new TenantInfo(Guid.NewGuid().ToString(), "empty1");
        var fakeTenant = new TenantInfo(Guid.NewGuid().ToString(), "test");
        var emptyTenant2 = new TenantInfo(Guid.NewGuid().ToString(), "empty2");

        // Act
        var manager = new MultiTenancyManager(Substitute.For<IAmbientTenantAccessor>(),
            [
                new TenantResolverAction(context => 
                {
                    context.Tenant = emptyTenant1;
                }),
                new TenantResolverAction(context =>
                {
                    context.Tenant = fakeTenant;
                    context.Handled = true;
                }),
                new TenantResolverAction(context =>
                {
                    context.Tenant = emptyTenant2;
                    context.Handled = true;
                })
            ]);

        // Assert
        manager.CurrentTenant.ShouldBe(fakeTenant);
    }

    [Fact]
    public void Should_Get_Ambient_Tenant_If_Changed()
    {
        // Arrange
        var oldTenant = new TenantInfo(Guid.NewGuid().ToString(), "old-tenant");

        var manager = new MultiTenancyManager(Substitute.For<IAmbientTenantAccessor>(), 
            [
                new TenantResolverAction(context =>
                {
                    context.Tenant = oldTenant;
                    context.Handled = true;
                })
            ]);

        manager.CurrentTenant.ShouldBe(oldTenant);

        // Act
        var overridedTenant = new TenantInfo(Guid.NewGuid().ToString(), "overrided-tenant");
        using (manager.ChangeTenant(overridedTenant))
        {
            // Assert
            manager.CurrentTenant.ShouldBe(overridedTenant);
        }
        // Assert
        manager.CurrentTenant.ShouldBe(oldTenant);
    }   
}