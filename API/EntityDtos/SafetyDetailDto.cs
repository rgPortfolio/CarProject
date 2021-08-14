using Newtonsoft.Json;

namespace API.EntityDtos
{
    public class SafetyDetailDto
    {
        [JsonProperty("Rating")]
        public decimal Rating { get; set; }
    }
}