using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> feature/sign-up

namespace KFCClone.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        public string? Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = null!;

<<<<<<< HEAD
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "IsGuestUser is required")]
        public bool IsGuestUser { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
=======
        [Column("is_guest_user")]
        public bool IsGuestUser { get; set; }

        [Column("contact_number")]
>>>>>>> feature/sign-up
        public string ContactNumber { get; set; } = null!;

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }

        [ForeignKey("StateId")]
        public int StateId { get; set; }

        [ForeignKey("CityId")]
        public int CityId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
