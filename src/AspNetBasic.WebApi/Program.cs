using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AspNetBasic.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load(".env");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configureWebHostDefaults = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

            return configureWebHostDefaults;
        }
    }
}
