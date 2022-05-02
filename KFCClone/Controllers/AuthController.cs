using System.Security.Claims;
using AutoMapper;
using KFCClone.DTOs.Auth;
using KFCClone.DTOs.Checkout;
using KFCClone.Interfaces;
using KFCClone.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        private readonly IDropDownListUtils _dropDownListUtils;

        public AuthController(IAuthRepository authRepository, DataContext context, IMapper mapper, IJwtUtils jwtUtils, IDropDownListUtils dropDownListUtils)
        {
            _auth = authRepository;
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
            _dropDownListUtils = dropDownListUtils;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            RegisterRequestBodyDto registerRequestBodyDto = new RegisterRequestBodyDto();
            ViewBag.ErrorMessage = null;
            return View(_dropDownListUtils.SetDropDownListValues(registerRequestBodyDto));
            
        }

        // [HttpPost("register")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRequestBodyDto requestBodyDto)
        {
            // if (requestBodyDto == null) return BadRequest();

            // return Ok(await _auth.RegisterAsync(requestBodyDto));

            try
            {
                if (ModelState.IsValid){
                    await _auth.RegisterAsync(requestBodyDto, HttpContext);
                    return RedirectToAction("Index", "Home");
                }
                
                return View(_dropDownListUtils.SetDropDownListValues(requestBodyDto));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(_dropDownListUtils.SetDropDownListValues(requestBodyDto));
            }
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
        public async Task<IActionResult> Login(LoginRequestBodyDto requestBodyDto, string? returnUrl, bool isCheckOutForm)
        {
            try
            {
                if (ModelState.IsValid){
                    await _auth.LoginAsync(requestBodyDto, HttpContext);

                    if(isCheckOutForm){
                        return RedirectToAction("Index", "Checkout");
                    }

                    if(!string.IsNullOrEmpty(returnUrl)){
                        return LocalRedirect(returnUrl);
                    }

                    
                    return RedirectToAction("Index", "Home");
                }

                if(isCheckOutForm){
                    return RedirectToAction("Index", "Checkout");
                }
                return View(requestBodyDto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(requestBodyDto);
            }
        }

    }
}