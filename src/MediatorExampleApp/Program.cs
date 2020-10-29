namespace MediatorExampleApp
{
    using System;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using Serilog.Events;
    using Serilog.Sinks.Graylog;

    public class Program
    {
        public static void Main(string[] args)
        {
            var graylogAddress = Environment.GetEnvironmentVariable("GRAYLOG_ADDRESS") ?? "localhost";
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .WriteTo.Graylog(new GraylogSinkOptions
                        {
                            HostnameOrAddress = graylogAddress,
                            Port = 12201,
                        })
                        .CreateLogger();

            try
            {
                Log.Information("Starting host...");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Host terminated unexpectedly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureAppConfiguration((_, config) =>
                {
                    config.AddEnvironmentVariables(prefix: "CONFIG_");
                }).ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
