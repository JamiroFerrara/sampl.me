using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    [HttpGet(Name = "Ping")]
    public string Get()
    {
        return "Pong";
    }
}
