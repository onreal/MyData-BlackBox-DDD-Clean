using Upio.MyData.BlackBox.Application.Models;
using Upio.MyData.BlackBox.Application.Translators;
using Upio.MyData.BlackBox.Core.Services.Http;
using Upio.MyData.BlackBox.Service.Client.Contract;

namespace Upio.MyData.BlackBox.Application.Adapters;

public class InvoiceAdapter
{
    private readonly IHttpClient httpClient;

    public InvoiceAdapter(IHttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IHttpResponse> SendAsync(InvoicesList invoicesList)
    {
        try
        {
            var invoiceDoc = await new InvoiceDocTranslator().fromModelAsync(invoicesList);
            
            return await this.httpClient.SendAsync(invoiceDoc);
        }
        catch (Exception e)
        {
            throw new Exception("Error while sending invoice", e);
        }
    }
}