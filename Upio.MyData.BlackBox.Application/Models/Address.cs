using System.Text.Json.Serialization;

namespace Upio.MyData.BlackBox.Application.Models
{
    public abstract class Address
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; } 
    }
}