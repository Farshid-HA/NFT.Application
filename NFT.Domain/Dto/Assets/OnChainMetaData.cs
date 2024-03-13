using System.Text.Json.Serialization;

namespace NFT.Domain.Dto.Assets
{
    public class OnChainMetaData
    {
        [JsonPropertyName("Beak")]
        public string? Break { get; set; }
        [JsonPropertyName("Body")]
        public string? Body { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("image")]
        public string? Image { get; set; }
        [JsonPropertyName("Eyewear")]
        public string? EyeWear { get; set; }
        [JsonPropertyName("Twitter")]
        public string? Twitter { get; set; }
        [JsonPropertyName("Website")]
        public string? Website { get; set; }
        [JsonPropertyName("Clothing")]
        public string? Clothing { get; set; }
        [JsonPropertyName("Headwear")]
        public string? Headwear { get; set; }
        [JsonPropertyName("Eye Color")]
        public string? EyeColor { get; set; }
        [JsonPropertyName("Eye Shape")]
        public string? EyeShape { get; set; }
        [JsonPropertyName("mediaType")]
        public string? MediaType { get; set; }
        [JsonPropertyName("Background")]
        public string? Background { get; set; }
        [JsonPropertyName("Background Portals")]
        public string? BackgroundPortal { get; set; }
        [JsonPropertyName("Background Accessories")]
        public string? BackgroundAccessories { get; set; }
        [JsonPropertyName("Foreground Accessories")]
        public string? ForegroundAccessories { get; set; }
    }
}
