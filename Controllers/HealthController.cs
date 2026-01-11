using Microsoft.AspNetCore.Mvc;

namespace FlowTasks.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("FlowTasks API is running");
    }
}
