using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class ContactController : Controller
    {

        private readonly CommentService _commentService;

        public ContactController(CommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _commentService.RegisterCommentAsync(viewModel))
                {
                    return RedirectToAction("Index", "Contact");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(viewModel);
                }
                
            }
            return View(viewModel);
        }

    }
}
