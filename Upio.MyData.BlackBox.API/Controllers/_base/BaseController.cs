using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Upio.MyData.BlackBox.Controllers._base
{
    public class BaseController<T> : ControllerBase
    {
        private ILogger<T> _logger;

        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}