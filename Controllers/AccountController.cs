using Bmerketo.Services.Repo;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;



[Authorize]
public class AccountController : Controller
{
    private readonly UserRepository _userRepository;

    public AccountController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new UsersViewModel
        {
            Users = await _userRepository.GetAllAsync(x => x.Email == User.Identity!.Name)

        };
        return View(viewModel);

    }
}
