using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AddressEntity> AspNetAddresses { get; set; }

        public DbSet<UserAddressEntity> AspNetUserAddresses { get; set; }

    }
}
