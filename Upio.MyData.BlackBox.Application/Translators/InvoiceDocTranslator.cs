using Upio.MyData.BlackBox.Application.Models;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Application.Translators;

public class InvoiceDocTranslator
{
    public async Task<InvoicesDoc> fromModelAsync(InvoicesList invoicesList)
    {
        return await Task.Run(async () =>
        {
            var bookInvoiceTypes = new List<AadeBookInvoiceType>();
            
            foreach (var invoice in invoicesList.Invoice)
            {
                var bookInvoiceType = await new InvoiceTranslator().fromModelAsync(invoice);
                bookInvoiceTypes.Add(bookInvoiceType);
            }
            
            var invoiceDoc = new InvoicesDoc()
            {
                invoice = bookInvoiceTypes
            };

            return InvoicesDoc.Parse(invoiceDoc.ToString());
        });
    }
}