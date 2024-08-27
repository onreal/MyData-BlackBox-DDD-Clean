using Upio.MyData.BlackBox.Core.Schema;
using Upio.MyData.BlackBox.Core.Services.Http;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Infrastructure;

public class HttpResponse : IHttpResponse
{
    public ResponseDoc ResponseDoc { get; set; }
    public RequestedDoc RequestedDoc { get; set; }
    public bool IsError { get; set; }
    public string? Message { get; set; }
}