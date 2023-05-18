using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
