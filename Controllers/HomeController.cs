using Microsoft.AspNetCore.Mvc;

namespace NoahStener_KodprovLIA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
