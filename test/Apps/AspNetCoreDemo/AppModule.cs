using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Builder;
using Volo.Abp.AspNetCore;

namespace AspNetCoreDemo;

[DependOn(typeof(AbpAspNetCoreModule))]
public class AppModule : IAbpModule, IConfigureAspNet
{
    public void ConfigureServices(IServiceCollection services)
    {
    }
    
    public void Configure(AspNetConfigurationContext context)
    {
        // context.LoggerFactory.AddConsole();

        if (context.Environment.IsDevelopment())   
        {
            context.App.UseDeveloperExceptionPage();
        }

        context.App.Run(async (ctx) =>
        {
            await ctx.Response.WriteAsync("Hello World 3!");
        });
    }

}