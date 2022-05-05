using KFCClone.DTOs.Checkout;

namespace KFCClone.Interfaces
{
    public interface ICheckoutRepository
    {
        Task<CheckoutDto> GetUserDetailsAsync(string email);

        // Task<CheckoutDto> CheckGuestUserAsync(string Email);
        Task<CheckoutDto?> PlaceOrderAsync(CheckoutDto checkoutDto);

    }
}
