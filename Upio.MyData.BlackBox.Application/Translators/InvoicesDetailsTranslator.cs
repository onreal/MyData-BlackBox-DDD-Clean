using System.ComponentModel;
using https.www.aade.gr.myDATA.incomeClassificaton.v1.Item0;
using Upio.MyData.BlackBox.Application.Helpers;
using Upio.MyData.BlackBox.Application.Models;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Application.Translators;

public class InvoicesDetailsTranslator
{
    public async Task<List<InvoiceRowType>> fromModelAsync(List<InvoiceDetail> invoiceDetails)
    {
        return await Task.Run(async () =>
        {
            var invoiceRowType = new List<InvoiceRowType>();
            for (var i = 0; invoiceDetails.Count > i; i++)
            {
                var classification = await Helper.GetIncomeClassification(
                    invoiceDetails[i].IncomeClassification.ClassificationCategory,
                    invoiceDetails[i].IncomeClassification.ClassificationType,
                    Convert.ToDecimal(invoiceDetails[i].IncomeClassification.Amount));
                var incomeClassification = new List<IncomeClassificationType>
                {
                    classification
                };
                
                var invoiceTypeRow = new InvoiceRowType
                {
                    lineNumber = i + 1,
                    netValue = Convert.ToDecimal(invoiceDetails[i].NetValue),
                    vatCategory = Convert.ToInt32(invoiceDetails[i].VatCategory),
                    vatAmount = Convert.ToDecimal(invoiceDetails[i].VatAmount),
                    incomeClassification = incomeClassification
                };
                
                var vatExemptionCategory = invoiceDetails[i].VatExemptionCategory;
                if (vatExemptionCategory != null)
                {
                  invoiceTypeRow.vatExemptionCategory =
                            int.Parse(vatExemptionCategory);
                }

                invoiceRowType.Add(invoiceTypeRow);
            }

            return invoiceRowType;
        });
    }
}