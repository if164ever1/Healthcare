using Healthcare.Data;
using Healthcare.Models;
using Healthcare.Models.Responce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace Healthcare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class HomeController : Controller
    {
        private readonly UserContext userContext;
        public HomeController(UserContext context)
        {
            userContext = context;
        }
        [HttpGet]
        public IActionResult Index(/*[FromHeader(Name = "KEY")][Required] string requiredHeader*/)
        {

            HttpContext.Request.Headers.TryGetValue("token", out var token);

            var user = userContext.Tokens.SingleOrDefault(x => x.Token == token.ToString());

            return Ok(userContext.Users.Where(u => u.Id == user.Id));
        }
    }

}

