using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using justauth.src.Models.ServicesModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace justauth.src.Services.JWT 
{
    public class TokenJwtService : ITokenJwtService
    {
        private IConfiguration _configuration;
        
        public TokenJwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public ServiceJwtResponse GenerateToken(string email)
        {
            var keySecretToToken = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            double time =  Convert.ToDouble(_configuration["Jwt:Time"]);

            JwtSecurityTokenHandler TokenHandle = new JwtSecurityTokenHandler();
            

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(time),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keySecretToToken),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = TokenHandle.CreateToken(tokenDescriptor);
            
            return new ServiceJwtResponse {
                Email = email,
                Token = TokenHandle.WriteToken(token),
                Expiration = token.ValidTo
            }; 
        } 
    }
}