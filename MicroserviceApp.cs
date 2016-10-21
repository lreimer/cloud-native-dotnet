using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace QAware.OSS
{
    public class MicroserviceApp
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
             .UseKestrel()
             .UseStartup<Startup>()
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
