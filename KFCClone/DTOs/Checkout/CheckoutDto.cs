using System.ComponentModel.DataAnnotations;
using KFCClone.DTOs.Auth;
using KFCClone.DTOs.Cart;
using KFCClone.Enumerations;
using KFCClone.Models;

namespace KFCClone.DTOs.Checkout
{
    public class CheckoutDto
    {
        [EnumDataType(typeof(PaymentType))]
        public PaymentType PaymentType { get; set; }
        public List<CartItemDto> Products { get; set; } = null!;
        public int OrderTotal { get; set; }

        public CheckoutUserDetailsDto UserDetails { get; set; } = null!;

        public bool? IsGuestUser { get; set; } = null;
    }
}