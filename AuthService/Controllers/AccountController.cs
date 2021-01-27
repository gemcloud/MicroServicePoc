using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthService.Models;
using AuthService.Services;

namespace AuthService.Controllers
{
    [Authorize]   // 
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly AuthenticationService authService;

        public AccountController(AuthenticationService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]  // 
        [HttpPost]
        public IActionResult Post([FromBody] LoginViewModel user)
        {
            var token = authService.Authenticate(user.Login, user.Password);

            if (token == null)
                return BadRequest(new { message = "Username of password incorrect" });

            return Ok(new { Token = token });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(authService.GetUserFromLogin(HttpContext.User.Identity.Name));
        }
    }
}
