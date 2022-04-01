using AutoMapper;
using KFCClone.DTOs.Product;
using KFCClone.Models;

namespace KFCClone.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetCategoryProductsResponseDto>();
            CreateMap<Product, GetProductByIdResponseDto>();
        }
    }
}
