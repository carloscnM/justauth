using System.Threading;
using System.Threading.Tasks;
using justauth.src.Domain.Commands.Requests;
using justauth.src.Domain.Commands.Responses;
using justauth.src.Models;
using justauth.src.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace justauth.src.Domain.Handlers 
{
    public class LogonHandler : IRequestHandler<LogonRequest, UserResponse>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public LogonHandler(SignInManager<User> signInManager,
            ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<UserResponse> Handle(LogonRequest request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, isPersistent:false, lockoutOnFailure:false);
            if (result.Succeeded){
                var token = _tokenService.GenerateToken(request.Email);
                return new UserResponse(token.Email, token.Token, token.Expiration);
            }
            return new UserResponse(400, "Email or passWord Invalid");
        }
    }
}