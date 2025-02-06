using ChatApp.Models;
using ChatApp.Services;
using ChatApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _authService.RegisterAsync(model.Username, model.Email, model.Password);
            if (result.Contains("Invalid"))
                return BadRequest(result);

            return Ok(new { token = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _authService.LoginAsync(model.Email, model.Password);
            if (result.Contains("Invalid"))
                return Unauthorized(result);

            return Ok(new { token = result });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            var result = await _authService.ForgotPasswordAsync(model.Email);
            return Ok(new { message = result });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var success = await _authService.ResetPasswordAsync(model.Email, model.Token, model.NewPassword);
            if (!success) return BadRequest("Invalid token or email");

            return Ok(new { message = "Password has been reset" });
        }
    }
}
