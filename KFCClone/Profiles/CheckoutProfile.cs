using AutoMapper;
using KFCClone.DTOs.Auth;
using KFCClone.DTOs.Category;
using KFCClone.Models;

namespace KFCClone.Profiles
{
    public class CheckoutProfile : Profile
    {
        public CheckoutProfile()
        {
            CreateMap<User, CheckoutUserDetailsDto>();
            CreateMap<CheckoutUserDetailsDto, User>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
        }
    }
}
