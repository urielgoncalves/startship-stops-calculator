using Microsoft.Extensions.Options;
using StarWarsApp.Core.Aggregates;
using StarWarsApp.Core.Interfaces;
using StarWarsApp.Shared.Enums;
using System;

namespace StarWarsApp
{
    public class StopsCalculator
    {
        private readonly IStarshipService _starshipService;
        private readonly Settings _settings;
        public StopsCalculator(IStarshipService starshipService, IOptions<Settings> settings)
        {
            _starshipService = starshipService;
            _settings = settings.Value;
        }

        public void Run()
        {
            ShowHeader();

            var quit = false;
            var starshipsURL = _settings.StarshipsURL;
            long travelDistance = AskForTheTravelDistance();
            (string, string) previousNextUrls = ("","");
            ConsoleNavigation answerNextPage = ConsoleNavigation.Quit;

            while(!quit)
            {
                // Get starships
                if (!string.IsNullOrEmpty(starshipsURL))
                {
                    var ships = _starshipService.GetStarships(starshipsURL);

                    if (ships == null)
                    {
                        Console.WriteLine("Starships not found.");
                        continue;
                    }

                    previousNextUrls = ShowStarships(ships.Result, travelDistance);
                }

                // Navigation
                answerNextPage = AskNextAction();

                if (answerNextPage != ConsoleNavigation.Quit)
                {
                    if (string.IsNullOrEmpty(previousNextUrls.Item1))
                        Console.WriteLine("");
                    starshipsURL = _starshipService.GetUrl(answerNextPage, previousNextUrls.Item1, previousNextUrls.Item2);
                }
                else quit = true;
            };
        }

        private long AskForTheTravelDistance()
        {
            Console.WriteLine("Please input the travel distance (MGLT): ");
            bool validDistance = false;
            long travelDistance = 0;
            do
            {
                var inputTravelDistance = Console.ReadLine();
                validDistance = long.TryParse(inputTravelDistance, out travelDistance);
                if (!validDistance || travelDistance <= 0)
                {
                    Console.WriteLine("Invalid distance. Try again...");
                }
            } while (!validDistance || travelDistance <= 0);

            return travelDistance;
        }

        private ConsoleNavigation AskNextAction()
        {
            Console.WriteLine("1=Previous page | 2=Next page | 0 = Quit");
            return (ConsoleNavigation)int.Parse(Console.ReadLine());
        }

        private void ShowHeader()
        {
            Console.WriteLine("Ship guide - Stops for resupply");
            Console.WriteLine("*** -1: We have no information to calculate.");
            Console.WriteLine();
            Console.WriteLine();
        }

        private (string previousUrl, string nextUrl) ShowStarships(StarshipAggregate ships, long travelDistance)
        {
            foreach (var ship in ships.Starships)
            {
                var stopsForResupply = _starshipService.CalculateStopsForResupply(ship, travelDistance);

                Console.WriteLine($"Ship Name: {ship.Name} | Stops for resupply: {stopsForResupply}");
                Console.WriteLine();
            }
            Console.WriteLine("=================================================");
            return (ships.Previous, ships.Next);
        }
    }
}
