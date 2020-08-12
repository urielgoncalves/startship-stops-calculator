using Microsoft.VisualBasic;
using StarWarsApp.Core.Aggregates;
using StarWarsApp.Core.DTO;
using StarWarsApp.Core.Interfaces;
using StarWarsApp.Shared;
using StarWarsApp.Shared.Enums;
using StarWarsApp.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApp.Infrastructure
{
    public class StarshipService : IStarshipService
    {
        private readonly IHelper _helper;

        public StarshipService(IHelper helper)
        {
            _helper = helper;
        }
        public async Task<StarshipAggregate> GetStarships(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            try
            {
                using (var client = new HttpClient())
                {
                    var requestResult = await client.GetAsync(url);
                    return _helper.Deserialize<StarshipAggregate>(requestResult.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Consumable FormatPeriod(string period)
        {
            switch (period.ToLower())
            {
                case "year":
                case "years":
                    return Consumable.Years;
                case "month":
                case "months":
                    return Consumable.Months;
                case "week":
                case "weeks":
                    return Consumable.Weeks;
                case "day":
                case "days":
                    return Consumable.Days;
                default:
                    return Consumable.Unknown;
            }
        }

        private int GetIntervalForNextResupplyInHours(string consumables)
        {
            string[] arrInterval = consumables.Split(" ");

            if (arrInterval.Length < 2)
                return (int)Consumable.Unknown;

            Consumable period = FormatPeriod(arrInterval[1]);

            if (period == Consumable.Unknown)
                return (int)Consumable.Unknown;

            int quantityByPeriod = int.Parse(arrInterval[0]);

            return (int)period * quantityByPeriod;
        }
        
        public decimal CalculateStopsForResupply(StarshipDTO ship, long distance)
        {
            var intervalInHoursForNextResupply = GetIntervalForNextResupplyInHours(ship.Consumables);

            if (intervalInHoursForNextResupply == -1)
                return -1;
            
            int.TryParse(ship.MGLT, out int shipMGLT);
            if (shipMGLT == 0)
                return -1;

            return Math.Round((decimal)distance / (intervalInHoursForNextResupply * shipMGLT));
        }

        public string GetUrl(ConsoleNavigation answer, string previousUrl, string nextUrl)
        {
            switch (answer)
            {
                case ConsoleNavigation.Previous:
                    return previousUrl;
                case ConsoleNavigation.Next:
                    return nextUrl;
                default:
                    return string.Empty;
            }
        }
    }
}
