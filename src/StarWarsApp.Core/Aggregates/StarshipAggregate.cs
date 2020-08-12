using Jil;
using StarWarsApp.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsApp.Core.Aggregates
{
    public class StarshipAggregate
    {
        [JilDirective(Name = "count")]
        public int Count { get; set; }
        [JilDirective(Name = "next")]
        public string Next { get; set; }
        [JilDirective(Name = "previous")]
        public string Previous { get; set; }
        [JilDirective(Name = "results")]
        public IEnumerable<StarshipDTO> Starships { get; set; }
    }
}
