using KFCClone.DTOs.Auth;
using KFCClone.Models;

namespace KFCClone
{
    public interface IAuthRepository
    {
        Task RegisterAsync(RegisterRequestBodyDto requestBodyDto, HttpContext httpContext);
        Task LoginAsync(LoginRequestBodyDto requestBodyDto, HttpContext httpContext);

        Task<CheckoutUserDetailsDto> CheckGuestUserAsync(string Email);
    }
}
