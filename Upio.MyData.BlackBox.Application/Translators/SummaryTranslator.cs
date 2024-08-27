using https.www.aade.gr.myDATA.incomeClassificaton.v1.Item0;
using Upio.MyData.BlackBox.Application.Helpers;
using Upio.MyData.BlackBox.Application.Models;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Application.Translators;

public class SummaryTranslator
{
    public async Task<InvoiceSummaryType> fromModelAsync(InvoiceRequest invoice)
    {
        return await Task.Run(async () =>
        {
            var totalNetValue = decimal.Zero;
            var totalVatAmount = decimal.Zero;
            var totalGrossValue = decimal.Zero;
            var incomeClassification = new List<IncomeClassificationType>();
            
            foreach (var detail in invoice.InvoiceDetails)
            {
                var mydataRevenueCategoryType = detail.IncomeClassification.ClassificationCategory;
                var mydataRevenueCategory = detail.IncomeClassification.ClassificationType;
                var parsedMydataRevenueCategory = Enum.Parse<IncomeClassificationValueType>(mydataRevenueCategory);
                var grossAmount = decimal.Round(decimal.Parse(detail.NetValue) + decimal.Parse(detail.VatAmount), 2);
                var vatAmount = decimal.Round(decimal.Parse(detail.VatAmount), 2);
                var netAmount = decimal.Round(decimal.Parse(detail.NetValue), 2);
                
                totalNetValue += netAmount;
                totalVatAmount += vatAmount;
                totalGrossValue += grossAmount;
                
                var existingClassification = 
                    incomeClassification.FindIndex(a => a.classificationType.Equals(parsedMydataRevenueCategory));
                if (existingClassification >= 0)
                {
                    incomeClassification[existingClassification].amount = totalNetValue;
                } 
                else
                {
                    incomeClassification.Add(await Helper.GetIncomeClassification(mydataRevenueCategoryType, 
                        mydataRevenueCategory, totalNetValue));
                }
            }
            
            return new InvoiceSummaryType
            {
                totalNetValue = totalNetValue,
                totalVatAmount = totalVatAmount,
                totalWithheldAmount = Convert.ToDecimal(invoice.InvoiceSummary.totalWithheldAmount),
                totalFeesAmount = Convert.ToDecimal(invoice.InvoiceSummary.totalFeesAmount),
                totalStampDutyAmount = Convert.ToDecimal(invoice.InvoiceSummary.totalStampDutyAmount),
                totalOtherTaxesAmount = Convert.ToDecimal(invoice.InvoiceSummary.totalOtherTaxesAmount),
                totalDeductionsAmount = Convert.ToDecimal(invoice.InvoiceSummary.totalDeductionsAmount),
                totalGrossValue = totalGrossValue,
                incomeClassification = incomeClassification
            };
        });
    }
}