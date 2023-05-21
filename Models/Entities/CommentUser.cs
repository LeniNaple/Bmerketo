using Bmerketo.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo.Models.Entities
{
    public class CommentUser
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Alias { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? Company { get; set; }

        public ICollection<ContactComment> Comments { get; set; } = new HashSet<ContactComment>();

    }
}
