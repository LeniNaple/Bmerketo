using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Contexts
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {
        }

        public DbSet<CommentUser> CommentInfos { get; set; } = null!;

        public DbSet<ContactComment> Comments { get; set; } = null!;

    }
}
