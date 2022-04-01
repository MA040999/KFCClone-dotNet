using KFCClone.DTOs.Product;
using KFCClone.DTOs.Category;
using KFCClone.Models;

namespace KFCClone.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<GetCategoriesResponseDto>> GetCategoriesAsync();
        Task<List<GetCategoryProductsResponseDto>> GetCategoryProducts(int categoryId);
    }
}
