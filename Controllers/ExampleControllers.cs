using Microsoft.AspNetCore.Mvc;

namespace API_SECURITY.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Hello, World!" });
        }
    }
}