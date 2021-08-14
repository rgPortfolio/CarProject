using System;
using Newtonsoft.Json;

namespace API.EntityDtos
{
    public class CarImageDto
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }
        [JsonProperty("ImageDataUrl")]
        public string ImageDataUrl { get; set; }
    }
}