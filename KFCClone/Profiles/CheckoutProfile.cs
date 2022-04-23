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
        }
    }
}
