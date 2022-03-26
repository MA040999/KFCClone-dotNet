using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KFCClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DbContext _context;
        public AuthController(DbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return Ok(new { token = "admin" });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
