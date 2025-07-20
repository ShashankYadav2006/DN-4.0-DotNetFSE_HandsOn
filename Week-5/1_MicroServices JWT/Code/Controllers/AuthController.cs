using Microsoft.AspNetCore.Mvc;
using JwtAuthMicroservice.Models;
using JwtAuthMicroservice.Services;

namespace JwtAuthMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IJwtService jwtService, ILogger<AuthController> logger)
        {
            _jwtService = jwtService;
            _logger = logger;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            try
            {
                if (string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
                {
                    return BadRequest(new { message = "Username and password are required" });
                }
                if (!_jwtService.ValidateCredentials(loginModel.Username, loginModel.Password))
                {
                    _logger.LogWarning("Failed login attempt for username: {Username}", loginModel.Username);
                    return Unauthorized(new { message = "Invalid username or password" });
                }
                var user = _jwtService.GetUserByUsername(loginModel.Username);
                if (user == null)
                {
                    return Unauthorized(new { message = "User not found" });
                }
                var token = _jwtService.GenerateToken(user);
                _logger.LogInformation("User {Username} logged in successfully", user.Username);
                return Ok(new 
                { 
                    message = "Login successful",
                    token = token,
                    user = new 
                    {
                        id = user.Id,
                        username = user.Username,
                        email = user.Email,
                        role = user.Role
                    },
                    expiresIn = "60 minutes"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login process");
                return StatusCode(500, new { message = "An error occurred during login" });
            }
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "Auth controller is working!", timestamp = DateTime.UtcNow });
        }
    }
}