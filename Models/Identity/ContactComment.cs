using Bmerketo.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo.Models.Identity
{
    public class ContactComment
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Comment { get; set; } = null!;

        public bool SaveEmail { get; set; } = true!;


        [ForeignKey(nameof(Id))]
        public Guid CommentId { get; set; }

        public CommentUser CommentInfo { get; set; } = null!; 



    }
}
