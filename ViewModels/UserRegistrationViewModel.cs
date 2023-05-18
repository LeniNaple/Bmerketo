using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo.ViewModels
{
    public class UserRegistrationViewModel
    {

        [Required(ErrorMessage = "A First Name is required")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "A Last Name is required")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "An Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "A password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "You have to confirm your password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        public string StreetName { get; set; } = null!;

        public string? PostalCode { get; set; }

        public string? City { get; set; }

        public string? CompanyName { get; set; }

        public string? ProfileImageUrl { get; set; }

        [Required(ErrorMessage = "You must agree to the terms and conditions.")]
        public bool TermsAndAgreement { get; set; } = false;


        public static implicit operator AppUser(UserRegistrationViewModel viewModel)
        {
            return new AppUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                PhoneNumber = viewModel.PhoneNumber,
                CompanyName = viewModel.CompanyName,
                ImageUrl = viewModel.ProfileImageUrl,

            };
        }

        public static implicit operator AddressEntity(UserRegistrationViewModel viewModel)
        {
            return new AddressEntity
            {
                StreetName = viewModel.StreetName,
                PostalCode = viewModel.PostalCode,
                City = viewModel.City,

            };
        }

    }
}
