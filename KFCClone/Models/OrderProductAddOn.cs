using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFCClone.Models
{
    public partial class OrderProductAddOn
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Order Product ID is required")]
        [ForeignKey(nameof(Models.OrderProduct))]
        public int OrderProductId { get; set; }

        [Required(ErrorMessage = "AddOn ID is required")]
        [ForeignKey(nameof(Models.AddOn))]
        public int AddOnId { get; set; }

        [Required(ErrorMessage = "AddOn Quantity is required")]
        public int AddOnQuantity { get; set; }

        public virtual AddOn AddOn { get; set; } = null!;
        public virtual OrderProduct OrderProduct { get; set; } = null!;
    }
}
