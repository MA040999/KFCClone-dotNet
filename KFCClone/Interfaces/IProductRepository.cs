using KFCClone.DTOs.Product;
using KFCClone.Models;

namespace KFCClone.Interfaces
{
    public interface IProductRepository
    {
        Task<GetProductByIdResponseDto> GetProductById(int productId);
    }
}
