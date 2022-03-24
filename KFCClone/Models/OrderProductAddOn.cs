using System;
using System.Collections.Generic;

namespace KFCClone.Models
{
    public partial class OrderProductAddOn
    {
        public int Id { get; set; }
        public int OrderProductId { get; set; }
        public int AddOnId { get; set; }
        public int AddOnQuantity { get; set; }

        public virtual AddOn AddOn { get; set; } = null!;
        public virtual OrderProduct OrderProduct { get; set; } = null!;
    }
}
