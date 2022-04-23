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
        private readonly IDropDownListUtils _dropDownListUtils;

        public CheckoutController(IDropDownListUtils dropDownListUtils, IHttpContextAccessor httpContextAccessor, ICheckoutRepository checkoutRepository)
        {
            _dropDownListUtils = dropDownListUtils;
            _httpContextAccessor = httpContextAccessor;
            _checkoutRepository = checkoutRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            string email = _httpContextAccessor.HttpContext!.User.Claims.Where(x => x.Type.Contains("emailaddress")).ToList()[0].Value;
            if (email == null)
            {
                return View();
            }
            
            CheckoutDto checkoutDetails = await _checkoutRepository.GetUserDetailsAsync(email);
            
            return View(_dropDownListUtils.SetDropDownListValues(checkoutDetails.UserDetails));
        }
    }
}
