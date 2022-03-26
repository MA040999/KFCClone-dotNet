using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int? DrinkCount { get; set; }
        public bool IsMeal { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<ProductAddOn> ProductAddOns { get; set; }
    }
}
