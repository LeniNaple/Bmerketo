using Bmerketo.Services.Repo;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;



public class AdminController : Controller
{
    private readonly UserRepository _userRepository;

    public AdminController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Index()
    {
        var viewModel = new UsersViewModel
        {
            Users = await _userRepository.GetAllAsync()
        };
        return View(viewModel);

    }

}
