using Jil;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsApp.Core.DTO
{
    public class StarshipDTO
    {
        [JilDirective(Name = "name")]
        public string Name { get; set; }
        [JilDirective(Name = "model")]
        public string Model { get; set; }
        [JilDirective(Name = "manufacturer")]
        public string Manufacturer { get; set; }
        [JilDirective(Name = "cost_in_credits")]
        public string CostInCredits { get; set; }
        [JilDirective(Name = "length")]
        public string Length { get; set; }
        [JilDirective(Name = "max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }
        [JilDirective(Name = "crew")]
        public string Crew { get; set; }
        [JilDirective(Name = "passengers")]
        public string Passengers { get; set; }
        [JilDirective(Name = "cargo_capacity")]
        public string CargoCapacity { get; set; }
        [JilDirective(Name = "consumables")]
        public string Consumables { get; set; }
        [JilDirective(Name = "hyperdrive_rating")]
        public string HyperdriveRating { get; set; }
        [JilDirective(Name = "MGLT")]
        public string MGLT { get; set; }
        [JilDirective(Name = "starship_class")]
        public string StarshipClass { get; set; }
        [JilDirective(Name = "pilots")]
        public IEnumerable<string> Pilots { get; set; }
        [JilDirective(Name = "films")]
        public IEnumerable<string> Films { get; set; }
        [JilDirective(Name = "created")]
        public string Created { get; set; }
        [JilDirective(Name = "edited")]
        public string Edited { get; set; }
        [JilDirective(Name = "url")]
        public string Url { get; set; }
    }
}
