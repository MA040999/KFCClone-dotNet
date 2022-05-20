using KFCClone.DTOs.Auth;
using KFCClone.Models;

namespace KFCClone
{
    public interface IHomeRepository
    {
        Task<List<Product>> GetHomePageProductsAsync();
        Task<List<Promotion>> GetPromotions();
    }
}
