using justauth.src.Models.ServicesModel;

namespace justauth.src.Services.JWT
{
    public interface ITokenJwtService
    {
        public ServiceJwtResponse GenerateToken(string email);
    }
}