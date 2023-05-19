using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class ContactController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactFormViewModel viewModel)
        {
            return View(viewModel);
        }

    }
}
