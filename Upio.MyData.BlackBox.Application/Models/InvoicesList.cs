using System.Text.Json.Serialization;

namespace Upio.MyData.BlackBox.Application.Models
{
    public class InvoicesList
    {
        [JsonPropertyName("invoice")]
        public List<InvoiceRequest> Invoice { get; set; }
    }
}