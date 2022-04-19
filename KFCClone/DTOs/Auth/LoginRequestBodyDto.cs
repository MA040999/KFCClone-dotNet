using System.ComponentModel.DataAnnotations;

namespace KFCClone.DTOs.Auth
{
    public class LoginRequestBodyDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = null!;
        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

    }
}
