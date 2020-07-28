using justauth.src.Models;

namespace justauth.src.Services.JWT
{
    public interface ITokenService
    {
        public UserAuthentificad GenerateToken(string email);
    }
}