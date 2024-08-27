using System.Text.Json.Serialization;

namespace Upio.MyData.BlackBox.Application.Models
{
    public abstract class Issuer
    {
        [JsonPropertyName("vatNumber")]
        public string VatNumber { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("branch")]
        public string? Branch { get; set; }
        [JsonPropertyName("address")]
        public Address Address { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}