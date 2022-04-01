using AutoMapper;
using KFCClone.DTOs.Product;
using KFCClone.DTOs.Category;
using KFCClone.Interfaces;
using KFCClone.Models;

namespace KFCClone.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<List<GetCategoriesResponseDto>> GetCategoriesAsync()
        {
            List<Category> category = await _context.Categories.ToListAsync();

            if (category.Count == 0) throw new KeyNotFoundException("No categories available");

            return _mapper.Map<List<GetCategoriesResponseDto>>(category);
        }

        public async Task<List<GetCategoryProductsResponseDto>> GetCategoryProducts(int categoryId)
        {
            List<Product> products = await _context.Products.Where((x) => x.CategoryId == categoryId).ToListAsync();
            if (products.Count == 0) throw new KeyNotFoundException("No products available for this category");

            return _mapper.Map<List<GetCategoryProductsResponseDto>>(products);
        }
    }
}
