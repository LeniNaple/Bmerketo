using Bmerketo.Services;
using Bmerketo.Services.Repo;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;



public class AdminController : Controller
{
    private readonly UserRepository _userRepository;

    public AdminController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    
    public async Task<IActionResult> Index()
    {
        var viewModel = new UsersViewModel
        {
            Users = await _userRepository.GetAllAsync()
        };
        return View(viewModel);


    }

}
