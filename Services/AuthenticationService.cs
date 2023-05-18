using Bmerketo.Contexts;
using Bmerketo.Models.Identity;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bmerketo.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AddressService _addressService;
        private readonly SeedService _seedService;
        private readonly IdentityContext _identityContext;


        public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, SeedService seedService, IdentityContext identityContext)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
            _seedService = seedService;
            _identityContext = identityContext;
        }

        public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }


        public async Task<bool> RegisterUserAsync(UserRegistrationViewModel viewModel)
        {
            bool result;
            AppUser appUser = viewModel;

            try
            {
                await _seedService.SeedRoles();
                var roleName = "user";

                if (!await _userManager.Users.AnyAsync())
                    roleName = "admin";
                else
                    roleName = "user";

                await _userManager.CreateAsync(appUser, viewModel.Password);
                await _userManager.AddToRoleAsync(appUser, roleName);
                await _identityContext.SaveChangesAsync();

                result = true;

            } catch{
                result = false;
            }

            if (result == true) 
            {
                var addressEntity = await _addressService.GetOrCreateAsync(viewModel);
                if (addressEntity != null)
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);

                    return true;
                }
            }
            return false;
        }

        public async Task<bool> LogInAsync(UserLoginViewModel viewModel)
        {
            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
                if (appUser != null)
                {
                   var result = await _signInManager.PasswordSignInAsync(appUser, viewModel.Password, viewModel.RememberMe, false);
                    return result.Succeeded;
                }
                return false;
        }

       

    }
}
