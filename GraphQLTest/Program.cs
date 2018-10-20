using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace GraphQLTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                               .AddJsonFile("./settings.json")
                               .Build();
            return WebHost
                  .CreateDefaultBuilder(args)
                  .UseConfiguration(configuration)
                  .UseStartup<Startup>();
        }
    }
}
