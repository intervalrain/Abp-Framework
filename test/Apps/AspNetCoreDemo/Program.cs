namespace AspNetCoreDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .ConfigureLogging(config =>
            {
                config.AddConsole();
            })
            .Build();

        host.Run();
    }
}