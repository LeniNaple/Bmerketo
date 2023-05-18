using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Bmerketo.Models.Identity;

public class CustomClaimsPrincipleFactory : UserClaimsPrincipalFactory<AppUser>
{
    private readonly UserManager<AppUser> _userManager;


    public CustomClaimsPrincipleFactory(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
    {
        _userManager = userManager;
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
    {
        var claimsIdentity = await base.GenerateClaimsAsync(user);

        claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}"));


        return claimsIdentity;
    }
}
