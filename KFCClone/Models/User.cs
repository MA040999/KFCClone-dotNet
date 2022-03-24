using System;
using System.Collections.Generic;

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
        public string Country { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public bool IsGuestUser { get; set; }
        public string ContactNumber { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
