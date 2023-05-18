using Bmerketo.Contexts;
using Bmerketo.Models.Entities;

namespace Bmerketo.Services.Repo
{
    public class AddressRepository : Repository<AddressEntity>
    {
        public AddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
