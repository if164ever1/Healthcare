using Microsoft.AspNetCore.Mvc;


namespace Healthcare.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }

}

