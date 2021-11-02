using Healthcare.Data;
using Healthcare.Models;
using Healthcare.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly UserContext userContext;
        public RegistrationController(UserContext context)
        {
            userContext = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequest userRequest)
        {
            if (userContext.Users.FirstOrDefault(u => u.Email == userRequest.Email) != null)
            {
                return BadRequest("Login already use");
            }

            UserModel userModel = new UserModel
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                Password = userRequest.Password
            };

            userContext.Users.Add(userModel);
            await userContext.SaveChangesAsync();

            return Ok("Registration is succesfuly");
        }
    }
}
