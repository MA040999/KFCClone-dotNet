using KFCClone.DTOs.AddOn;
using KFCClone.DTOs.Drink;

namespace KFCClone.DTOs.Cart
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public string Image { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Price { get; set; }

        public int Quantity { get; set; }

        public List<AddOnDto>? Drinks { get; set; }
        public List<AddOnDto>? AddOns { get; set; }
        public List<AddOnDto>? Upsize { get; set; }
        public List<AddOnDto>? FriesSize { get; set; }
    }
}
