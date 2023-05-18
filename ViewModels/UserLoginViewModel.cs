using System.ComponentModel.DataAnnotations;

namespace Bmerketo.ViewModels
{
    public class UserLoginViewModel
    {
        [Display(Name = "E-mail Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; } = "/";

    }
}
