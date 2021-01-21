using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace SecondApp
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
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    if (hostingContext.HostingEnvironment.IsDevelopment())
                        config.AddJsonFile($"{Directory.GetParent(Directory.GetCurrentDirectory())}/FirstApp/sharedsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json");
                    else
                        config.AddJsonFile($"sharedsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json");
                });
    }
}
