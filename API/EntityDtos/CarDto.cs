using System.Collections.Generic;
using API.Entities;
using Newtonsoft.Json;

namespace API.EntityDtos
{
    public class CarDto
    {
        [JsonProperty("make")]
		public string Make { get; set; }
		[JsonProperty("Model")]
		public string Model { get; set; }
		[JsonProperty("Year")]
		public int Year { get; set; }
		[JsonProperty("Images")]
		public List<CarImage>? CarImages { get; set; }

        public InteriorDetailDto InteriorDetail { get; set; }
        public ExteriorDetailDto ExteriorDetail { get; set; }
        public EngineDetailDto EngineDetail { get; set;}
        public SafetyDetailDto SafetyDetailDto { get; set;}
}