using Microsoft.AspNetCore.Mvc;

namespace CqrsSample.Api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("ping")]
        public ActionResult HeathCheck() => Ok("OK");

    }
}