using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class AddProductsController : Controller
    {

        private readonly ProductService _productService;

        public AddProductsController(ProductService productService)
        {
            _productService = productService;
        }



        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Index(AddProductsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.ProductExists(viewModel))
                {
                    return RedirectToAction("Index", "AddProducts");
                }
                else
                {
                    ModelState.AddModelError("", "A product with this name already exists.");
                    return View(viewModel);
                }

            }
            return View(viewModel);
        }
    }
}
