using Newtonsoft.Json;

namespace API.EntityDtos
{
    public class ExteriorDetailDto
    {
        [JsonProperty("Color")]
        public string? Color { get; set; }

        [JsonProperty("Rims")]
        public string? Rims { get; set; }
    }
}