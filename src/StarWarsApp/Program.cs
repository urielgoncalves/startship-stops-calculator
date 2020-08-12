using Microsoft.Extensions.DependencyInjection;
using StarWarsApp.Core.Interfaces;
using System;
using System.Linq;

namespace StarWarsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Star Wars Application!");
            var configuration = Startup.Configure();
            var services = Startup.ConfigureServices(configuration);
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<StopsCalculator>().Run();
        }
    }
}
