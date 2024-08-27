using System.Text.Json.Serialization;

namespace Upio.MyData.BlackBox.Application.Models
{
    public abstract class InvoiceRequest
    {
        [JsonPropertyName("issuer")]
        public Issuer Issuer { get; set; }
        [JsonPropertyName("counterpart")]
        public Counterpart Counterpart { get; set; }
        [JsonPropertyName("invoiceHeader")]
        public InvoiceHeader InvoiceHeader { get; set; }
        [JsonPropertyName("paymentMethods")]
        public PaymentMethods PaymentMethods { get; set; }
        [JsonPropertyName("invoiceDetails")]
        public List<InvoiceDetail> InvoiceDetails { get; set; }
        [JsonPropertyName("invoiceSummary")]
        public InvoiceSummary InvoiceSummary { get; set; }
    }
}
