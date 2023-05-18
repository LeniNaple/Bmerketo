using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
