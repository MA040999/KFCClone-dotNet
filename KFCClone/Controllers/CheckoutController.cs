using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KFCClone.Controllers
{
    public class CheckoutController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
