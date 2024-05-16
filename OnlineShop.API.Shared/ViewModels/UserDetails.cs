using System.ComponentModel.DataAnnotations;

namespace OnlineShop.API.Shared.ViewModels
{
    public class UserDetails
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password should atleast 6 letters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please select a country")]
        public int? CountryId { get; set; }

        [Required(ErrorMessage = "Please select a state")]
        public int? StateId { get; set; }
    }
}
