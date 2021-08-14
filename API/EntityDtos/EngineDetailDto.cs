using Newtonsoft.Json;

namespace API.EntityDtos
{
    public class EngineDetailDto
    {
        [JsonProperty("HorsePower")]
        public int HorsePower { get; set; }
        [JsonProperty("Liters")]
        public decimal Liters { get; set; }
        [JsonProperty("Turbo")]

        public bool Turbo { get; set; }
    }
}