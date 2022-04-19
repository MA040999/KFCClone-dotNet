using KFCClone.DTOs.Auth;
using KFCClone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KFCClone.Controllers
{
    //[Route("api/auth")]
    //[ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _auth;
        public AuthController(IAuthRepository authRepository)
        {
            _auth = authRepository;
        }

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
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email, Password")] LoginRequestBodyDto requestBodyDto)
        {
            if (ModelState.IsValid){
                LoginResponseBodyDto loginResponse = await _auth.LoginAsync(requestBodyDto);
                if(loginResponse.ErrorMessage == null)
                    return RedirectToAction("Index", "Home", new RouteValueDictionary(requestBodyDto));
                
                ViewBag.ErrorMessage = loginResponse.ErrorMessage;
            }
            return View(requestBodyDto);
        }
    }
}