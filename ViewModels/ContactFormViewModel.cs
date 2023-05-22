using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo.ViewModels
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "An alias is required")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "An email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        public string? Company { get; set; }

        [Required(ErrorMessage = "You need to write a comment")]
        [DataType(DataType.Text)]
        public string Comment { get; set; } = null!;

        public bool RememberMyEmail { get; set; } = false;



        public static implicit operator CommentUser(ContactFormViewModel viewModel)
        {
            return new CommentUser
            {
                Alias = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Company = viewModel.Company,
            };
        }

        public static implicit operator ContactComment(ContactFormViewModel viewModel)
        {
            return new ContactComment
            {
                Comment = viewModel.Comment,
                SaveEmail = viewModel.RememberMyEmail,
            };
        }

    }
}
