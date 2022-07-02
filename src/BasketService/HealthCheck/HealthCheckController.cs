using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewhouseIT.BasketService.Baskets.Routes
{
   [Route("/api/ping")]
    [ApiController]
    public class HealthCheckController: ControllerBase
    {
        [HttpGet] public IActionResult Get() => new OkObjectResult("Service is healthy");
    }
}
