using Healthcare.Data;
using Healthcare.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;



using System.Threading.Tasks;

namespace Healthcare.Controllers
{

    //[Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IUserContext userContext;
        public HomeController(IUserContext context)
        {
            userContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            return await Task.Run(() => View());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserModel user)
        {

            if (ModelState.IsValid)
            {
                user.Token = user.Id + user.LastName;

                userContext.Users.Add(user);
                await userContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                //var checkEmailInDb = null; //userContext.Users.FirstOrDefault(u => u.Email == user.Email);
                //if (checkEmailInDb == null)
                //{
                //    userContext.Users.Add(user);
                //    await userContext.SaveChangesAsync();
                //    return RedirectToAction(nameof(Index));
                //}
                //else 
                //{
                //    ViewBag.error = "Email allready exist!";
                //    return View();
                //}
            }
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Login(UserLogin userLogin)
        {
           
            if (ModelState.IsValid)
            {
                var users = from u in userContext.Users
                            where u.Email.Contains(userLogin.Email)
                            select u;
                var pas = from s in users where s.Password.Contains(userLogin.Password) select s;

                if (pas.Count() == 0)
                {
                    return "Incorect email or password";
                }

                var token = (from t in userContext.Users
                            where t.Email == userLogin.Email
                            select t.Token).First().ToString();
                return $"Hello {userLogin.Email} , your TOKEN is {token}";
            }
            return "Is empty";
        }
    }

}

