using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KFCClone.Models
{
    public partial class AddOn
    {
        public AddOn()
        {
            OrderProductAddOns = new HashSet<OrderProductAddOn>();
            ProductAddOns = new HashSet<ProductAddOn>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public bool IsUpsize { get; set; }
        public bool IsDrink { get; set; }

        [Column("is_fries_size")]
        public bool? IsFriesSize { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderProductAddOn> OrderProductAddOns { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProductAddOn> ProductAddOns { get; set; }
    }
}
