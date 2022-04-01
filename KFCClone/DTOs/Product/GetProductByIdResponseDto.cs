using KFCClone.Models;

namespace KFCClone.DTOs.Product
{
    public class GetProductByIdResponseDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public string ProductImage { get; set; } = null!;
        public int ProductPrice { get; set; }
        public int? DrinkCount { get; set; }
        public bool IsMeal { get; set; }

        public int CategoryId { get; set; }
        public virtual ICollection<ProductAddOn> ProductAddOns { get; set; } = null!;
    }
}
