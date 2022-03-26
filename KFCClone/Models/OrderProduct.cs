using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFCClone.Models
{
    public partial class OrderProduct
    {
        public OrderProduct()
        {
            OrderProductAddOns = new HashSet<OrderProductAddOn>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Product Quantity is required")]
        public int ProductQuantity { get; set; }

        [Required(ErrorMessage = "Order ID is required")]
        [ForeignKey(nameof(Models.Order))]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        [Required(ErrorMessage = "Product ID is required")]
        [ForeignKey(nameof(Models.Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<OrderProductAddOn> OrderProductAddOns { get; set; }
    }
}
