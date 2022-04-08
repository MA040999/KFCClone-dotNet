using KFCClone.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KFCClone.Controllers
{
    // [Route("api/category")]
    // [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet()]
        [Route("Category/GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryRepository.GetCategoriesAsync());
        }

        [HttpGet]
        [Route("Category/{categoryId}")]
        public async Task<IActionResult> Index(int categoryId)
        {
            return View(await _categoryRepository.GetCategoryProducts(categoryId));
        }


    }
}
