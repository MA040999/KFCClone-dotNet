using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFCClone.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Password { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;

        public bool IsGuestUser { get; set; }
        public string ContactNumber { get; set; } = null!;

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;

        [ForeignKey("StateId")]
        public int StateId { get; set; }
        public virtual State State { get; set; } = null!;

        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public virtual City City { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
