using Upio.MyData.BlackBox.Application.Models;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Application.Translators;

public class PaymentMethodsTranslator
{
    public async Task<AadeBookInvoiceType.paymentMethodsLocalType> fromModelAsync(PaymentMethods paymentMethods)
    {
        return await Task.Run(() =>
        {
            var paymentMethod = new AadeBookInvoiceType.paymentMethodsLocalType();
            var paymentMethodDetails = paymentMethods.PaymentMethodDetails.Select(
                payment => new PaymentMethodDetailType { type = int.Parse(payment.Type), amount = decimal.Parse(payment.Amount) }).ToList();

            paymentMethod.paymentMethodDetails = paymentMethodDetails;

            return paymentMethod;
        });
    }
}