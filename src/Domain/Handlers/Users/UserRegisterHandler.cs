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
    public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, UserResponse>
    {
        private readonly ITokenJwtService _tokenService;
        private readonly UserManager<User> _userManager;

        public UserRegisterHandler(ITokenJwtService tokenService,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<UserResponse> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            if(await _userManager.FindByEmailAsync(request.Email) != null){
                 return new UserResponse("User already registered");
            }

            User user = new User(request.FirstName, request.LastName, request.Email);
            var result = await _userManager.CreateAsync(user, request.Password);
            if(result.Succeeded){
                var token = _tokenService.GenerateToken(user.Email);
                return new UserResponse(token.Email, token.Token, token.Expiration);
            }
            return new UserResponse("One or more errors occurred during registration");
        }

    }
}