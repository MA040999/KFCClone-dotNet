using System.ComponentModel.DataAnnotations;

namespace KFCClone.DTOs.Auth
{
    public class RegisterRequestBodyDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Passowrd is required")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Confirm Passowrd is required")]
        public string ConfirmPassword { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
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

        //[Required(ErrorMessage = "IsGuestUser is required")]
        //public bool IsGuestUser { get; set; }
        [RegularExpression(@"^((\+92)?(0092)?(92)?(0)?)(3)([0-9]{9})$", ErrorMessage = "Please enter a valid mobile number")]
        [Required(ErrorMessage = "Contact Number is required")]
        public string ContactNumber { get; set; } = null!;
    }
}
