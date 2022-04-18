using AutoMapper;
using KFCClone.DTOs.Auth;
using KFCClone.Models;

namespace KFCClone.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterRequestBodyDto, User>();
            CreateMap<User, RegisterResponseBodyDto>();

            CreateMap<User, LoginResponseBodyDto>();
        }
    }
}
