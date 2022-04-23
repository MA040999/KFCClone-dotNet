using KFCClone.DTOs.Checkout;

namespace KFCClone.Interfaces
{
    public interface ICheckoutRepository
    {
        Task<CheckoutDto> GetUserDetailsAsync(string email);
    }
}
