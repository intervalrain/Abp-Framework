using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Modularity;

namespace AspNetCoreDemo;

[DependOn(typeof(AbpAspNetCoreModule))]
public class AppModule : AbpModule
{
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        if (context.GetEnvironment().IsDevelopment())   
        {
            app.UseDeveloperExceptionPage();
        }

        app.Run(async (ctx) =>
        {
            await ctx.Response.WriteAsync("Hello World 3!");
        });
    }

}