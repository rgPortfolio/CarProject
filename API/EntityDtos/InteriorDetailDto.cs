using Newtonsoft.Json;

namespace API.EntityDtos
{
    public class InteriorDetailDto
    {

        [JsonProperty("Upholstery")]
        public string? Upholstery { get; set; }
        [JsonProperty("SoundSystem")]
        public string? SoundSystem { get; set; }
        [JsonProperty("HasAndroidAutoOrCarPlay")]
        public bool? HasAndroidAutoOrCarPlay { get; set; }
    }
}