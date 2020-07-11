using justauth.src.Models;

namespace justauth.src.Services
{
    public interface ITokenService
    {
        public UserAuthentificad GenerateToken(string email);
    }
}