using Microsoft.AspNetCore.Mvc;

namespace Online_Exam.Controllers
{
    public class FeaturesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
