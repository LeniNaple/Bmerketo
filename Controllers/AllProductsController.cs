﻿using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class AllProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
