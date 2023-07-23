namespace TemplateCQRS.Presentation
{
    using Microsoft.AspNetCore.Hosting;
    using Serilog;
    using Serilog.Events;
    using Serilog.Formatting.Compact;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Template CQRS");
            try
            {
                var webHost = CreateHostBuilder(args).Build();

                await webHost.RunAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The Application BackOfficeApi failed to start. Error message {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Stopping Template CQRS");
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog((ctx, lc) => lc
                    .ReadFrom.Configuration(ctx.Configuration)
                    .Enrich.FromLogContext()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .WriteTo.Console(new CompactJsonFormatter())
                )
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }
}