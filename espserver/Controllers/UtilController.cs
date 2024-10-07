using Microsoft.AspNetCore.Mvc;

namespace espserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UtilController : ControllerBase
    {
        [HttpGet]
        public IActionResult Version()
        {
            return Ok("Api Version :V0.05");
        }
    }
}
