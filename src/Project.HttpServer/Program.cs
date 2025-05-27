using Database.Context;
using Project.HttpServer.Extensions;
using Serilog;

namespace Project.HttpServer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();
            
            var webHost = CreateHostBuilder(args).Build();

            await webHost.MigrateDatabaseAsync<ProjectDbContext>();

            await webHost.RunAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var webHost = Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureKestrel(serverOptions =>
                {
                    serverOptions.Limits.MaxRequestBodySize = null;
                    serverOptions.Limits.MaxResponseBufferSize = null;
                });
            });

        return webHost;
    }
}