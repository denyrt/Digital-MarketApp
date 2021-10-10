using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DigitalMarket
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
                    webBuilder.UseKestrel(options =>
                    {
                        options.ListenLocalhost(5000);
                        options.ListenLocalhost(5001, builder =>
                        {
                            builder.UseHttps();
                        });
                    });
                });
    }
}
