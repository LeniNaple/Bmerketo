using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class SignUpController : Controller
    {
        private readonly AuthenticationService _auth;

        public SignUpController(AuthenticationService auth)
        {
            _auth = auth;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserRegistrationViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                if (await _auth.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
                {
                    ModelState.AddModelError("", "A user with this email already exists.");
                    return View(viewModel);
                }

                if (await _auth.RegisterUserAsync(viewModel))
                {
                    return RedirectToAction("index", "login");
                }
            }
            return View(viewModel);
        }



    }
}
