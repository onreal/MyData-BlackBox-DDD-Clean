using System.Text.Json.Serialization;

namespace Upio.MyData.BlackBox.Application.Models
{
    public abstract class PaymentMethods
    {
        [JsonPropertyName("paymentMethodDetails")]
        public List<PaymentMethodDetails> PaymentMethodDetails { get; set; }
    }
}