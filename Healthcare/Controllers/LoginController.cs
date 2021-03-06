using Healthcare.Data;
using Healthcare.Models;
using Healthcare.Models.Responce;
using Healthcare.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : Controller
    {
        private readonly UserContext userContext;
        public LoginController(UserContext context)
        {
            userContext = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = userContext.Users.SingleOrDefault(x => x.Email == loginRequest.Email);

            var token = Guid.NewGuid().ToString();

            if (user == null || !(CustomHash.PasswordCheck(loginRequest.Password, user.Password)))
            {
                return BadRequest(new { message = "Login or Password is incorrect" });
            }

            var currentUserId = userContext.Tokens.SingleOrDefault(u => u.Id == user.Id);

            currentUserId.Token = token;

            await userContext.SaveChangesAsync();

            return Ok(new LoginResponse
            {
                Id = user.Id,
                Token = token
            });
        }
    }
}
