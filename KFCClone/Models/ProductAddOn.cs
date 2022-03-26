using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFCClone.Models
{
    public partial class ProductAddOn
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [ForeignKey(nameof(AddOn))]
        public int AddOnId { get; set; }

        public virtual AddOn AddOn { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
