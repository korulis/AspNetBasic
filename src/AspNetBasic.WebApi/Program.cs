using System;
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
            var webApiUrl = Environment.GetEnvironmentVariable("WEBAPIURL") ?? "";
            var configureWebHostDefaults = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    // webBuilder.UseUrls(webApiUrl);
                });

            return configureWebHostDefaults;
        }
    }
}
