using System.Security.Claims;
using AutoMapper;
using KFCClone.DTOs.Auth;
using KFCClone.DTOs.Checkout;
using KFCClone.Helpers;
using KFCClone.Interfaces;
using KFCClone.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KFCClone.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        public AuthRepository(DataContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }
        public async Task LoginAsync(LoginRequestBodyDto requestBodyDto, HttpContext httpContext)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == requestBodyDto.Email);
             //var user = await _context.Users.FindAsync(requestBodyDto.Email);      

            if (user == null || !BCrypt.Net.BCrypt.Verify(requestBodyDto.Password, user.Password)){
                throw new KeyNotFoundException("Invalid email or password");
            }

            SetAuthCookie(user.Email, user.Name, httpContext);
            // var response = _mapper.Map<LoginResponseBodyDto>(user);

            // response.Token = _jwtUtils.GenerateJwt(user);

            // response.Country = _context.Countries.SingleOrDefault(x => x.Id == user.CountryId)!.CountryName;
            // response.State = _context.States.SingleOrDefault(x => x.Id == user.StateId)!.StateName;
            // response.City = _context.Cities.SingleOrDefault(x => x.Id == user.CityId)!.CityName;

            // return response;
        }
        
        public async Task RegisterAsync(RegisterRequestBodyDto requestBodyDto, HttpContext httpContext)
        {
            if (_context.Users.Any(x => x.Email == requestBodyDto.Email))
                throw new ApplicationException("User with this email already exists");

            if (requestBodyDto.Password != requestBodyDto.ConfirmPassword)
                throw new ApplicationException("Passwords do not match");

            Country? country = await _context.Countries.FindAsync(requestBodyDto.CountryId);
            if (country == null)
                throw new KeyNotFoundException("Invalid Country");

            List<State>? state = _context.States.Where(x => x.Id == requestBodyDto.StateId && x.CountryId == country.Id).ToList();
            if (state.Count == 0)
                throw new KeyNotFoundException("Invalid State");

            List<City>? city = _context.Cities.Where(x => x.Id == requestBodyDto.CityId && x.StateId == state[0].Id).ToList();
            if (city.Count == 0)
                throw new KeyNotFoundException("Invalid City");

            User user = _mapper.Map<User>(requestBodyDto);

            user.Name = $"{requestBodyDto.FirstName} {requestBodyDto.LastName}";
            user.IsGuestUser = false;
            user.CountryId = country.Id;
            user.StateId = state[0].Id;
            user.CityId = city[0].Id;
            user.Password = BCrypt.Net.BCrypt.HashPassword(requestBodyDto.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            SetAuthCookie(requestBodyDto.Email, requestBodyDto.FirstName + " " + requestBodyDto.LastName, httpContext);

            // RegisterResponseBodyDto response = _mapper.Map<RegisterResponseBodyDto>(user);

            // response.Country = country.CountryName;
            // response.State = state[0].StateName;
            // response.City = city[0].CityName;

            // response.Token = _jwtUtils.GenerateJwt(user);

            // return response;
        }

        private async void SetAuthCookie(string Email, string Name, HttpContext httpContext){
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, Email),
                    new Claim(ClaimTypes.Name, Name),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };
                var principal = new ClaimsPrincipal(claimsIdentity);  

                await httpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    principal, 
                    authProperties);
        }
    }
}
