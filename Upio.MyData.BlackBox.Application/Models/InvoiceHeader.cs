using System.Text.Json.Serialization;

namespace Upio.MyData.BlackBox.Application.Models
{
    public abstract class InvoiceHeader
    {
        [JsonPropertyName("series")]
        public string Series { get; set; }
        [JsonPropertyName("aa")]
        public string Aa { get; set; }
        [JsonPropertyName("issueDate")]
        public string IssueDate { get; set; }
        [JsonPropertyName("invoiceType")]
        public string InvoiceType { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}