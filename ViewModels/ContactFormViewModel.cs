using System.ComponentModel.DataAnnotations;

namespace Bmerketo.ViewModels
{
    public class ContactFormViewModel
    {

        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        public string? Company { get; set; }

        [DataType(DataType.Text)]
        public string Comment { get; set; } = null!;

        public bool RememberMyEmail { get; set; } = false;

    }
}
