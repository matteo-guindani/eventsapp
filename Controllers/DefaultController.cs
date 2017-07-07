using Microsoft.AspNetCore.Mvc;

namespace EventsApp.Controllers
{
    [Route("")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "It works!";
        }
    }
}
