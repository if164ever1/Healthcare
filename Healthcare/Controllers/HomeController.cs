using Microsoft.AspNetCore.Mvc;


namespace Healthcare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Request.Headers.TryGetValue("token", out var token);
            
            return Ok();
        }
    }

}

