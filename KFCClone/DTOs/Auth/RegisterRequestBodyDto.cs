using System.ComponentModel.DataAnnotations;

namespace KFCClone.DTOs.Auth
{
    public class RegisterRequestBodyDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "IsGuestUser is required")]
        public bool IsGuestUser { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        public string ContactNumber { get; set; } = null!;
    }
}
