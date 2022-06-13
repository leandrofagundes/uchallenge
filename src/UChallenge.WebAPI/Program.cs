using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace UChallenge.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog((context, config) =>
                {
                    config.WriteTo.File(
                        path: "Logs\\UChallengeAPI.log",
                        retainedFileCountLimit: 7,
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose,
                        rollingInterval: RollingInterval.Day);

                    config.WriteTo.Console(
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information);
                });
    }
}
