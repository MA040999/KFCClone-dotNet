using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFCClone.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Order Total is required")]
        public int OrderTotal { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [ForeignKey(nameof(Models.User))]
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
