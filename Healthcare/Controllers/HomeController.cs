using Healthcare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;

using System.Threading.Tasks;

namespace Healthcare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
        public async Task<IActionResult> Login()
        {
            return await Task.Run(() => View());
        }

    }
}
