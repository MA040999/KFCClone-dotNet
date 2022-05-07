using AutoMapper;
using KFCClone.DTOs.AddOn;
using KFCClone.DTOs.Auth;
using KFCClone.DTOs.Cart;
using KFCClone.DTOs.Category;
using KFCClone.DTOs.Checkout;
using KFCClone.Models;

namespace KFCClone.Profiles
{
    public class CheckoutProfile : Profile
    {
        public CheckoutProfile()
        {
            CreateMap<User, CheckoutUserDetailsDto>();
            CreateMap<CheckoutDto, Order>();
            CreateMap<CartItemDto, OrderProduct>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.ProductQuantity, opt => opt.MapFrom(src => src.Quantity)).ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AddOnDto, OrderProductAddOn>().ForMember(dest => dest.AddOnQuantity, opt => opt.MapFrom(src => src.AddOnCount)).ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<CheckoutUserDetailsDto, User>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
        }
    }
}
