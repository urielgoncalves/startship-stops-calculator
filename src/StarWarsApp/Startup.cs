using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarWarsApp.Core.Interfaces;
using StarWarsApp.Infrastructure;
using StarWarsApp.Shared;
using StarWarsApp.Shared.Interfaces;

namespace StarWarsApp
{
    public class Startup
    {

        public static IConfiguration Configure()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static IServiceCollection ConfigureServices(IConfiguration configuration)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<StopsCalculator>();
            services.AddTransient<IHelper, Helper>();
            services.AddTransient<IStarshipService, StarshipService>();
            var settings = configuration.GetSection("settings");
            services.Configure<Settings>(x => settings.Bind(x));
            
            return services;
        }
    }
}
