using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KFCClone.DTOs.Auth
{
    public class CheckoutUserDetailsDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        public SelectList? Countries { get; set; } 

        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; } 
        
        public SelectList? States { get; set; } 

        [Required(ErrorMessage = "City is required")]
        public int CityId { get; set; }

        public SelectList? Cities { get; set; }

        //[Required(ErrorMessage = "IsGuestUser is required")]
        //public bool IsGuestUser { get; set; }
        
        [RegularExpression(@"^((\+92)?(0092)?(92)?(0)?)(3)([0-9]{9})$", ErrorMessage = "Please enter a valid mobile number")]
        [Required(ErrorMessage = "Contact Number is required")]
        public string ContactNumber { get; set; } = null!;
    }
}
