using Upio.MyData.BlackBox.Application.Models;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Application.Translators;

public class InvoiceTranslator
{
    public async Task<AadeBookInvoiceType> fromModelAsync(InvoiceRequest invoice)
    {
        return await Task.Run(async () =>
        {
            var issuer = await new IssuerTranslator().fromModelAsync(invoice.Issuer);
            var counterPart = await new CounterPartTranslator().fromModelAsync(invoice.Counterpart);
            var invoiceHeader = await new HeaderTranslator().fromModelAsync(invoice.InvoiceHeader);
            var paymentMethods = await new PaymentMethodsTranslator().fromModelAsync(invoice.PaymentMethods);
            var invoiceDetails = await new InvoicesDetailsTranslator().fromModelAsync(invoice.InvoiceDetails);
            var invoiceSummary = await new SummaryTranslator().fromModelAsync(invoice);
            
            var aadeBookInvoiceType = new AadeBookInvoiceType
            {
                issuer = issuer,
                invoiceHeader = invoiceHeader,
                paymentMethods = paymentMethods,
                invoiceDetails = invoiceDetails,
                invoiceSummary = invoiceSummary,
                counterpart = counterPart
            };

            return aadeBookInvoiceType;
        });
    }
}