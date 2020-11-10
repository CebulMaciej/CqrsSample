using Microsoft.AspNetCore.Mvc;

namespace CqrsSample.Api.Controllers
{
    [ApiController]
    [Route("ping")]
    public class HomeController : ControllerBase
    {
        public ActionResult HeathCheck() => Ok("OK");
    }
}