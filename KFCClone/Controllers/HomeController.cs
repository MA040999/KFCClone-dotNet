using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KFCClone.Models;
using KFCClone.ViewModel;

namespace KFCClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _homeRepository.GetHomePageProductsAsync();
            List<Promotion> promotions = await _homeRepository.GetPromotions();

            HomeViewModel homeViewModel = new HomeViewModel
            {
                products = products,
                promotions = promotions
            };

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}