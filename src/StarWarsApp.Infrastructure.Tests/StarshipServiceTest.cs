using StarWarsApp.Core.Aggregates;
using StarWarsApp.Core.DTO;
using StarWarsApp.Core.Interfaces;
using StarWarsApp.Shared;
using StarWarsApp.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StarWarsApp.Infrastructure.Tests
{
    public class StarshipServiceTest : TestBase
    {
        private const string STARSHIPS_URL = "https://swapi.dev/api/starships/";
        private readonly IHelper _helper;
        private readonly IStarshipService _starshipService;

        public StarshipServiceTest()
        {
            _helper = new Helper();
            _starshipService = new StarshipService(_helper);
        }

        [Fact]
        public void ShouldNotCalculateStopsForResupply()
        {
            int distance = 1000000;
            
            var result = _starshipService.CalculateStopsForResupply(StarshipDTOInvalidConsumables, distance);

            Assert.True(result == -1);
        }


        [Fact]
        public void ShouldCalculateStopsForResupply()
        {
            int distance = 1000000;
            
            var result = _starshipService.CalculateStopsForResupply(StarshipsDTO.ElementAt(0), distance);

            Assert.Equal(74, result);

            var result2 = _starshipService.CalculateStopsForResupply(StarshipsDTO.ElementAt(1), distance);

            Assert.Equal(9, result2);
        }

        [Fact]
        public void GetStarshipsEmptyUrl()
        {
            var result = _starshipService.GetStarships("").Result;

            Assert.Null(result);
        }

        [Fact]
        public void GetStarships()
        {
            var result = _starshipService.GetStarships(STARSHIPS_URL).Result;

            Assert.IsType<StarshipAggregate>(result);
        }
    }
}
