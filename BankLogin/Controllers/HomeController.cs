using BankLogin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankLogin.Controllers
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
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            
            if (IsValidUser(username, password))
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }


        private bool IsValidUser(string username, string password)
        {
            string defaultUsername = "username";
            string defaultPassword = "password";

            return username == defaultUsername && password == defaultPassword;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Dashboard()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
