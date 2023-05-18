using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class SingleProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
