using Upio.MyData.BlackBox.Core.Schema;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Core.Services.Http
{
    public interface IHttpResponse
    {
        public ResponseDoc? ResponseDoc { get; set; }
        public RequestedDoc? RequestedDoc { get; set; }
    }
}