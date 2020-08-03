using System.Threading;
using System.Threading.Tasks;
using justauth.src.Domain.Commands.Users;
using justauth.src.Domain.Entities;
using justauth.src.Models.Responses.Users;
using justauth.src.Services.JWT;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace justauth.src.Domain.Handlers.Users 
{
    public class UserLogonHandler : IRequestHandler<UserLogonCommand, UserResponse>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenJwtService _tokenService;

        public UserLogonHandler(SignInManager<User> signInManager,
            ITokenJwtService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<UserResponse> Handle(UserLogonCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, isPersistent:false, lockoutOnFailure:false);
            if (result.Succeeded){
                var token = _tokenService.GenerateToken(request.Email);
                return new UserResponse(token.Email, token.Token, token.Expiration);
            }
            return new UserResponse("Email or passWord Invalid");
        }
        
    }
}