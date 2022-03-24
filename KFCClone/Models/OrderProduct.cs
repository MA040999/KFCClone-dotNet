using System;
using System.Collections.Generic;

namespace KFCClone.Models
{
    public partial class OrderProduct
    {
        public OrderProduct()
        {
            OrderProductAddOns = new HashSet<OrderProductAddOn>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<OrderProductAddOn> OrderProductAddOns { get; set; }
    }
}
