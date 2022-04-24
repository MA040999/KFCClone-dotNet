using KFCClone.DTOs.Auth;
using KFCClone.DTOs.Checkout;
using KFCClone.Models;

namespace KFCClone
{
    public interface IAuthRepository
    {
        Task RegisterAsync(RegisterRequestBodyDto requestBodyDto, HttpContext httpContext);
        Task LoginAsync(LoginRequestBodyDto requestBodyDto, HttpContext httpContext);

    }
}
