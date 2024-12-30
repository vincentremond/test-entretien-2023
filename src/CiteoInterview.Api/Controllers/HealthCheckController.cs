using Microsoft.AspNetCore.Mvc;

namespace CiteoInterview.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheckController : ControllerBase
{
    [HttpGet(Name = "GetHealth")]
    public IActionResult Get()
    {
        return Ok("Health :-)");
    }
}
