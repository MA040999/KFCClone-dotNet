using System;
using System.Collections.Generic;

namespace KFCClone.Models
{
    public partial class ProductAddOn
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AddOnId { get; set; }

        public virtual AddOn AddOn { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
