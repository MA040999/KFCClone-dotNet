using System;
using System.Collections.Generic;

namespace KFCClone.Models
{
    public partial class Promotion
    {
        public int Id { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }
        public string? Url { get; set; }
        public string Image { get; set; } = null!;
    }
}
