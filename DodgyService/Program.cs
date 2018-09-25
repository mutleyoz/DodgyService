using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DodgyService
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(true)
                .UseKestrel()
                .UseStartup<StartUp>();

    }
}
