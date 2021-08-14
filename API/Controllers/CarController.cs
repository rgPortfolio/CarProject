using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger _logger;

        public CarController(ILogger logger)
        {
            _logger = logger;
        }
    }
}