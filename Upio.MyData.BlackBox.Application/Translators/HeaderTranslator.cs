using System.ComponentModel;
using Upio.MyData.BlackBox.Application.Models;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Application.Translators;

public class HeaderTranslator
{
    public async Task<InvoiceHeaderType> fromModelAsync(InvoiceHeader invoiceHeader)
    {
        return await Task.Run(() =>
        {
            if (!Enum.IsDefined(typeof(CurrencyType), invoiceHeader.Currency))
            {
                throw new InvalidEnumArgumentException();
            }

            return new InvoiceHeaderType
            {
                series = invoiceHeader.Series ?? "0",
                aa = $"{invoiceHeader.Aa}",
                issueDate = DateTime.Now,
                invoiceType = invoiceHeader.InvoiceType,
                currency = Enum.Parse<CurrencyType>(invoiceHeader.Currency)
            };
        });
    }
}