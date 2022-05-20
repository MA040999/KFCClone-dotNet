using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFCClone.Models
{
    public partial class Promotion
    {
        public int Id { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }

        [Column("product_id")]
        public int? ProductId { get; set; }
        public string Image { get; set; } = null!;
    }
}
