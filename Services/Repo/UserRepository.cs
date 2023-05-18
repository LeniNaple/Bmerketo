using Bmerketo.Contexts;
using Bmerketo.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Services.Repo;

public class UserRepository : Repository<AppUser>
{
    
    public UserRepository(IdentityContext context) : base(context)
    {
    }



}
