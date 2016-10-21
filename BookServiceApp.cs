using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace QAware.OSS
{
    public class BookServiceApp
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
            	.Build();

            var host = new WebHostBuilder()
             .UseKestrel()
             .UseStartup<Startup>()
             .UseConfiguration(config)
             .Build();

            host.Run();
        }
    }

    class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBooksRepository, MemoryBooksRepository>();
            services.AddMvc();
        }
    }
}
