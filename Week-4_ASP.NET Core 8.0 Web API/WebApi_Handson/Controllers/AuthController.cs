using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi_Handson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        [HttpGet("get-token/{role}")]
        public IActionResult GetToken(string role)
        {
            if (role != "Admin" && role != "POC")
                return BadRequest("Role must be either 'Admin' or 'POC'");

            var token = GenerateJSONWebToken(1, role);
            return Ok(new { token });
        }

        private string GenerateJSONWebToken(int userId, string userRole)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecretkeyforjwt12345678"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
