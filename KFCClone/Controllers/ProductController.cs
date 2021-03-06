using KFCClone.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KFCClone.Controllers
{
    // [Route("api/products")]
    // [ApiController]
    // public class ProductController : ControllerBase
    // {
    //     private readonly IProductRepository _productRepository;
    //     public ProductController(IProductRepository productRepository)
    //     {
    //         _productRepository = productRepository;
    //     }

    //     [HttpGet("{productId}")]
    //     public async Task<IActionResult> GetProductById([FromRoute] int productId)
    //     {
    //         return Ok(await _productRepository.GetProductById(productId));
    //     }

    // }

    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("Product/{productId}")]
        public async Task<IActionResult> Index(int productId)
        {
            return View(await _productRepository.GetProductById(productId));
        }

    }
}
