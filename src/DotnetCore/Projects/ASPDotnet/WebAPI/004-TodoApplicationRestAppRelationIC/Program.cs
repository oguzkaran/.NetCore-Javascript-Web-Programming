using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _001_TodoApplicationRestApp
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
                    webBuilder.UseUrls("http://162.168.1.3:50500");
                });
    }
}
