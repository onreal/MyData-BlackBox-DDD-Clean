using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Upio.MyData.BlackBox.Application.Adapters;
using Upio.MyData.BlackBox.Application.Models;
using Upio.MyData.BlackBox.Controllers._base;
using Upio.MyData.BlackBox.Core.Services.Http;

namespace Upio.MyData.BlackBox.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : BaseController<InvoiceController>
    {
        private readonly InvoiceAdapter invoiceAdapter;
        
        public InvoiceController(ILogger<InvoiceController> logger, InvoiceAdapter invoiceAdapter) 
            : base(logger)
        {
            this.invoiceAdapter = invoiceAdapter;
        }
        
        [HttpPost]
        public async Task<ActionResult<IHttpResponse>> Post([FromBody] InvoicesList invoicesList)
        {
            return Ok(await invoiceAdapter.SendAsync(invoicesList));
        }
    }
}