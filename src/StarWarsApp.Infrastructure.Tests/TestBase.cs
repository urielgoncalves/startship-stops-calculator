using StarWarsApp.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsApp.Infrastructure.Tests
{
    public class TestBase
    {
        public IEnumerable<StarshipDTO> StarshipsDTO => new[]
        {
            new StarshipDTO
            {
                Name = "Y-wing",
                Model = "BTL Y-wing",
                Manufacturer = "Koensayr Manufacturing",
                CostInCredits = "134999",
                Length = "14",
                MaxAtmospheringSpeed = "1000km",
                Crew = "2",
                Passengers = "0",
                CargoCapacity = "110",
                Consumables = "1 week",
                HyperdriveRating = "1.0",
                MGLT = "80",
                StarshipClass = "assault starfighter",
                Pilots = new List<string>(),
                Films = new List<string>
                {
                    "http://swapi.dev/api/films/1/",
                    "http://swapi.dev/api/films/2/",
                    "http://swapi.dev/api/films/3/"
                },
                Created = "2014-12-12T11:00:39.817000Z",
                Edited = "2014-12-20T21:23:49.883000Z",
                Url = "http://swapi.dev/api/starships/11/"
            },
            new StarshipDTO
            {
                Name = "Millennium Falcon",
                Model = "YT-1300 light freighter",
                Manufacturer = "Corellian Engineering Corporation",
                CostInCredits = "100000",
                Length = "34.37",
                MaxAtmospheringSpeed = "1050",
                Crew = "4",
                Passengers = "6",
                CargoCapacity = "100000",
                Consumables = "2 months",
                HyperdriveRating = "0.5",
                MGLT = "75",
                StarshipClass = "Light freighter",
                Pilots = new List<string>{
                     "http://swapi.dev/api/people/13/",
                    "http://swapi.dev/api/people/14/",
                    "http://swapi.dev/api/people/25/",
                    "http://swapi.dev/api/people/31/"
                },
                Films = new List<string>
                {
                    "http://swapi.dev/api/films/1/",
                    "http://swapi.dev/api/films/2/",
                    "http://swapi.dev/api/films/3/"
                },
                Created = "2014-12-10T16:59:45.094000Z",
                Edited = "2014-12-20T21:23:49.880000Z",
                Url = "http://swapi.dev/api/starships/10/"
            },
        };

        public StarshipDTO StarshipDTOInvalidConsumables => new StarshipDTO
        {
            Name = "Y-wing",
            Model = "BTL Y-wing",
            Manufacturer = "Koensayr Manufacturing",
            CostInCredits = "134999",
            Length = "14",
            MaxAtmospheringSpeed = "1000km",
            Crew = "2",
            Passengers = "0",
            CargoCapacity = "110",
            Consumables = "wasdasdasdk",
            HyperdriveRating = "1.0",
            MGLT = "80",
            StarshipClass = "assault starfighter",
            Pilots = new List<string>(),
            Films = new List<string>
            {
                "http://swapi.dev/api/films/1/",
                "http://swapi.dev/api/films/2/",
                "http://swapi.dev/api/films/3/"
            },
            Created = "2014-12-12T11:00:39.817000Z",
            Edited = "2014-12-20T21:23:49.883000Z",
            Url = "http://swapi.dev/api/starships/11/"
        };
    }
}
