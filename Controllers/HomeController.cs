using Microsoft.AspNetCore.Mvc;
using Online_Exam.Models;
using System.Diagnostics;

    namespace Online_Exam.Controllers
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
                var Name = HttpContext.Session.GetString("U_Email");

                if (string.IsNullOrEmpty(Name))
                {

                    return RedirectToAction("Signup", "Login");
                }
                ViewBag.WelcomeMessage = $"Welcome, {Name}!";
                return View();
            }

            public IActionResult Privacy()
            {
                return View();
            }
            public IActionResult Logout()
            {
                HttpContext.Session.Clear(); 
                return RedirectToAction("Signin", "Login"); 
            }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }