using JwtAuthMicroservice.Models;

namespace JwtAuthMicroservice.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        bool ValidateCredentials(string username, string password);
        User? GetUserByUsername(string username);
    }
}