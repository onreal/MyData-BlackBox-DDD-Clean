using System.Text.Json.Serialization;

namespace Upio.MyData.BlackBox.Application.Models
{
    public abstract class InvoiceDetail
    {
        [JsonPropertyName("lineNumber")]
        public string LineNumber { get; set; }
        [JsonPropertyName("netValue")]
        public string NetValue { get; set; }
        [JsonPropertyName("vatCategory")]
        public string VatCategory { get; set; }
        [JsonPropertyName("vatAmount")]
        public string VatAmount { get; set; }
        [JsonPropertyName("incomeClassification")]
        public IncomeClassification IncomeClassification { get; set; }
        [JsonPropertyName("vatExemptionCategory")]
        public string? VatExemptionCategory { get; set; }
    }
}