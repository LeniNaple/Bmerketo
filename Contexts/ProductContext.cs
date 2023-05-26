using Bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Contexts;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; } = null!;

}
