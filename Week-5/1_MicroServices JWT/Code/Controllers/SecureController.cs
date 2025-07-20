using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtAuthMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        private readonly ILogger<SecureController> _logger;

        public SecureController(ILogger<SecureController> logger)
        {
            _logger = logger;
        }
        [HttpGet("data")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            var username = User?.Identity?.Name;
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = User?.FindFirst(ClaimTypes.Role)?.Value;
            _logger.LogInformation("Secure data accessed by user: {Username}", username);
            return Ok(new 
            {
                message = "This is protected data that requires authentication",
                user = new 
                {
                    id = userId,
                    username = username,
                    role = userRole
                },
                timestamp = DateTime.UtcNow,
                data = new 
                {
                    secretInfo = "This information is only available to authenticated users",
                    serverInfo = "Microservice is running smoothly"
                }
            });
        }
        [HttpGet("public")]
        public IActionResult GetPublicData()
        {
            return Ok(new 
            {
                message = "This is public data available to everyone",
                timestamp = DateTime.UtcNow
            });
        }
    }
}