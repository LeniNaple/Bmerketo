using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }



        public async Task<IActionResult> Index()
        {
            var viewModel = new ProductsViewModel
            {
                Products = await _productService.GetAllProducts()
            };

            return View(viewModel);
        }
    }
}
