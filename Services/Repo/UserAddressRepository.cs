using Bmerketo.Contexts;
using Bmerketo.Models.Entities;

namespace Bmerketo.Services.Repo
{
    public class UserAddressRepository : Repository<UserAddressEntity>
    {
        public UserAddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
