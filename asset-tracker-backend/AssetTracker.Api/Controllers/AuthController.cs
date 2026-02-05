using AssetTracker.Application.DTO.Auth;
using AssetTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AssetTracker.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth) => _auth = auth;

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest req)
        {
            await _auth.RegisterAsync(req);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest req)
        {
            var ok = await _auth.VerifyLoginAsync(req);
            return ok ? Ok() : Unauthorized();
        }
        
        [HttpPut("{id:int}/password")]
        public async Task<IActionResult> ChangePassword(int id, ChangePasswordRequest req)
        {
            await _auth.ChangePasswordAsync(id, req);
            return NoContent();
        }
    }
}
