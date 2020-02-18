using Divayo.Localization.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Divayo.Localization.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Seq(Environment.GetEnvironmentVariable("SEQ_URL") ?? "http://localhost:5341")
            .CreateLogger();

            try
            {
                Log.Information("Starting up");
                var host = CreateHostBuilder(args).Build();

                SeedData(host);

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void SeedData(IHost host)
        {
            var scope = host.Services.CreateScope();
            Log.Information("Starting data seed.");
            Task.Run(() => DataGeneratorService.AddSeedDataAsync(scope));            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
