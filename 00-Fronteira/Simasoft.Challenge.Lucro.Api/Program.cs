using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Simasoft.Challenge.Lucro.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureLogging((webhostContext, builder) => {
                    builder.AddConfiguration(webhostContext.Configuration.GetSection("Logging"))
                    .AddFilter<ConsoleLoggerProvider>(logLevel => logLevel == LogLevel.Warning);
                })
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
