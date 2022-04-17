using System.ComponentModel.DataAnnotations;

namespace KFCClone.DTOs.Auth
{
    public class LoginRequestBodyDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;
        
        [Required(ErrorMessage = "Passowrd is required")]
        public string Password { get; set; } = null!;

    }
}
