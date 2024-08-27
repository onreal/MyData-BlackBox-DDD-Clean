using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Core.Services.Http;

public interface IHttpService
{
    public Task<IHttpResponse> SendAsync(InvoicesDoc invoicesDoc);
    public Task<IHttpResponse> Cancel(string mark);
    public Task<IHttpResponse> Request(string action);
    public Task<IHttpResponse> RequestTransmitted(string action);
    public Task<IHttpResponse> SendIncome(string action);
    public Task<IHttpResponse> SendExpenses(string action);
}