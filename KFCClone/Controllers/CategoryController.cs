using KFCClone.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KFCClone.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryRepository.GetCategoriesAsync());
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory([FromRoute] int categoryId)
        {
            return Ok(await _categoryRepository.GetCategoryProducts(categoryId));
        }
    }
}
