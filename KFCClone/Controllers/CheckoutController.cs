using KFCClone.DTOs.Auth;
using KFCClone.DTOs.Checkout;
using KFCClone.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KFCClone.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICheckoutRepository _checkoutRepository;

        public CheckoutController(IHttpContextAccessor httpContextAccessor, ICheckoutRepository checkoutRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _checkoutRepository = checkoutRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            var email = _httpContextAccessor.HttpContext!.User.Claims.Where(x => x.Type.Contains("emailaddress")).ToList();
            if (email.Count == 0)
            {
                CheckoutDto checkoutDto = new CheckoutDto();

                return View(checkoutDto);
            }
            
            CheckoutDto checkoutDetails = await _checkoutRepository.GetUserDetailsAsync(email[0].Value);
            
            return View(checkoutDetails);
        }

        [HttpPost]
        // [Route("Auth/CheckGuestUser")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckGuestUser(LoginRequestBodyDto requestBodyDto)
        {
            // if (requestBodyDto == null) return BadRequest();

            // return Ok(await _auth.CheckGuestUserAsync(requestBodyDto.Email));

            CheckoutDto checkoutDetails = await _checkoutRepository.GetUserDetailsAsync(requestBodyDto.Email);

            ViewBag.IsGuestUser = true;
            return View("Index", checkoutDetails);
        }
    }
}
