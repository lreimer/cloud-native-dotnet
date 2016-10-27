using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration;
using Steeltoe.Discovery.Client;

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
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddConfigServer(env);

            Configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDiscoveryClient();
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigServer(Configuration);
            services.AddDiscoveryClient(Configuration);
            services.AddSingleton<IBooksRepository, MemoryBooksRepository>();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddMvc();
        }
    }
}
