using System;
using System.Collections.Generic;

namespace KFCClone.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            ProductAddOns = new HashSet<ProductAddOn>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public string ProductImage { get; set; } = null!;
        public int ProductPrice { get; set; }
        public int CatergoryId { get; set; }
        public int? DrinkCount { get; set; }
        public bool IsMeal { get; set; }

        public virtual Category Catergory { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<ProductAddOn> ProductAddOns { get; set; }
    }
}
