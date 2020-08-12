using StarWarsApp.Core.Aggregates;
using StarWarsApp.Core.DTO;
using StarWarsApp.Shared.Enums;
using System.Threading.Tasks;

namespace StarWarsApp.Core.Interfaces
{
    public interface IStarshipService
    {
        Task<StarshipAggregate> GetStarships(string url);
        decimal CalculateStopsForResupply(StarshipDTO ship, long distance);
        string GetUrl(ConsoleNavigation answer, string previousUrl, string nextUrl);
    }
}
