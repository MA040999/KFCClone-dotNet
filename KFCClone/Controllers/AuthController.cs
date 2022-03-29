using KFCClone.DTOs.Auth;
using KFCClone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KFCClone.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
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
    }
}
