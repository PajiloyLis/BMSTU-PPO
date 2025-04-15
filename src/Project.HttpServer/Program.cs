using Serilog;

namespace Project.HttpServer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}