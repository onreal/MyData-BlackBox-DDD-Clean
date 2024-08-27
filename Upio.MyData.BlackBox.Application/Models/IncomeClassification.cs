using System.Text.Json.Serialization;

namespace Upio.MyData.BlackBox.Application.Models
{
    public abstract class IncomeClassification
    {
        [JsonPropertyName("classificationType")]
        public string ClassificationType { get; set; }
        [JsonPropertyName("classificationCategory")]
        public string ClassificationCategory { get; set; }
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
        
    }
}