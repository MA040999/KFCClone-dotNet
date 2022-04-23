using KFCClone.DTOs.AddOn;
using KFCClone.DTOs.Drink;

namespace KFCClone.DTOs.Cart
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string ProductImage { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int ProductPrice { get; set; }
        
        public int ProductQuantity { get; set; }
        public int ProductTotal { get; set; }

        public List<DrinkDto>? Drinks { get; set; }
        public List<AddOnDto>? AddOns { get; set; }
    }
}
