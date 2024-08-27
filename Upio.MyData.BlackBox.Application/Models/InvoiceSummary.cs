using System.Text.Json.Serialization;

namespace Upio.MyData.BlackBox.Application.Models
{
    public abstract class InvoiceSummary
    {
        [JsonPropertyName("totalNetValue")]
        public string totalNetValue { get; set; }
        [JsonPropertyName("totalVatAmount")]
        public string totalVatAmount { get; set; }
        [JsonPropertyName("totalWithheldAmount")]
        public string totalWithheldAmount { get; set; }
        [JsonPropertyName("totalFeesAmount")]
        public string totalFeesAmount { get; set; }
        [JsonPropertyName("totalStampDutyAmount")]
        public string totalStampDutyAmount { get; set; }
        [JsonPropertyName("totalOtherTaxesAmount")]
        public string totalOtherTaxesAmount { get; set; }
        [JsonPropertyName("totalDeductionsAmount")]
        public string totalDeductionsAmount { get; set; }
        [JsonPropertyName("totalGrossValue")]
        public string totalGrossValue { get; set; }
        [JsonPropertyName("incomeClassification")]
        public IncomeClassification incomeClassification { get; set; }
    }
}