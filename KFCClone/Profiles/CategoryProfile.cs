using AutoMapper;
using KFCClone.DTOs.Category;
using KFCClone.Models;

namespace KFCClone.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetCategoriesResponseDto>();
        }
    }
}
