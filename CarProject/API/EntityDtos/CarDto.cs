using System;
using System.Collections.Generic;
using API.Entities;
using Newtonsoft.Json;

namespace API.EntityDtos
{
    public class CarDto
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }
        [JsonProperty("make")]
		public string Make { get; set; }
		[JsonProperty("Model")]
		public string Model { get; set; }
		[JsonProperty("Year")]
		public int Year { get; set; }
		[JsonProperty("Images")]
		public List<CarImageDto>? CarImages { get; set; }
		[JsonProperty("InteriorDetail")]
        public InteriorDetailDto InteriorDetail { get; set; }
        [JsonProperty("ExteriorDetail")]
        public ExteriorDetailDto ExteriorDetail { get; set; }
        [JsonProperty("EngineDetail")]
        public EngineDetailDto EngineDetail { get; set;}
        [JsonProperty("SafetyDetail")]
        public SafetyDetailDto SafetyDetail { get; set;}
    }
}