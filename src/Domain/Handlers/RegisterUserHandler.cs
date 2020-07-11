using System;
using System.Linq;
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
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, UserResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterUserHandler(UserManager<User> userManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<UserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            if(await _userManager.FindByEmailAsync(request.Email) != null){
                 return new UserResponse(400, "User already registered");
            }

            User user = new User(request.FirstName, request.LastName, request.Email);
            var result = await _userManager.CreateAsync(user, request.Password);
            if(result.Succeeded){
                var token = _tokenService.GenerateToken(user.Email);
                return new UserResponse(token.Email, token.Token, token.Expiration);
            }
            return new UserResponse(400, "One or more errors occurred during registration");
        }
    }
}