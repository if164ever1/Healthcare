using Healthcare.Data;
using Healthcare.Models;
using Healthcare.Models.Request;
using Healthcare.Security;
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
        public async Task<IActionResult> Register(RegistrationRequest registerRequest)
        {
            if (userContext.Users.FirstOrDefault(u => u.Email == registerRequest.Email) != null)
            {
                return BadRequest(new { message = "Login already use" } );
            }

            UserModel userModel = new UserModel
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                Password = CustomHash.HashPassword(registerRequest.Password)
            };

            userContext.Users.Add(userModel);
            await userContext.SaveChangesAsync();

            return Ok( new { message = "Registration is succesfuly" } );
        }
    }
}
