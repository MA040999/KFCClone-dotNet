using System.Security.Claims;
using AutoMapper;
using KFCClone.DTOs.Auth;
using KFCClone.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KFCClone.Controllers
{
    //[Route("api/auth")]
    //[ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _auth;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;

        public AuthController(IAuthRepository authRepository, DataContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            _auth = authRepository;
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestBodyDto requestBodyDto)
        {
            if (requestBodyDto == null) return BadRequest();

            return Ok(await _auth.RegisterAsync(requestBodyDto));
        }

        // [HttpPost("login")]
        // public async Task<IActionResult> Login([FromBody] LoginRequestBodyDto requestBodyDto)
        // {
        //     if (requestBodyDto == null) 
        //         return BadRequest();

        //     return Ok(await _auth.LoginAsync(requestBodyDto));
        // }
        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email, Password")] LoginRequestBodyDto requestBodyDto, string? returnUrl)
        {
            if (ModelState.IsValid){
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == requestBodyDto.Email);  

                if (user == null || !BCrypt.Net.BCrypt.Verify(requestBodyDto.Password, user.Password)){

                    ViewBag.ErrorMessage = "Invalid Email or Password";
                    return View(requestBodyDto);
                }

                var response = _mapper.Map<LoginResponseBodyDto>(user);

                // response.Token = _jwtUtils.GenerateJwt(user);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name)
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

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    principal, 
                    authProperties);

                response.Country = _context.Countries.SingleOrDefault(x => x.Id == user.CountryId)!.CountryName;
                response.State = _context.States.SingleOrDefault(x => x.Id == user.StateId)!.StateName;
                response.City = _context.Cities.SingleOrDefault(x => x.Id == user.CityId)!.CityName;

                
                // return RedirectToAction("Index", "Home", new RouteValueDictionary(requestBodyDto));

                if(!string.IsNullOrEmpty(returnUrl)){
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            return View(requestBodyDto);
        }
    }
}