using Microsoft.AspNetCore.Mvc;

namespace CiteoInterview.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheckController : ControllerBase
{

    private readonly ILogger<ProductsController> _logger;

    public HealthCheckController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetHealth")]
    public IActionResult Get()
    {
        return Ok("Health :-)");
    }
}
