using System.Threading;
using System.Threading.Tasks;
using justauth.src.Domain.Commands.Requests;
using justauth.src.Domain.Commands.Responses;
using justauth.src.Models;
using justauth.src.Services.JWT;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace justauth.src.Domain.Handlers 
{
    public class LogonHandler : IRequestHandler<LogonRequest, UserResponse>,
        IRequestHandler<RegisterUserRequest, UserResponse>
    {

        #region propriety
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;

        #endregion

        #region constructs
        public LogonHandler(SignInManager<User> signInManager,
            ITokenService tokenService,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        #endregion

        #region logonUserhandler
        public async Task<UserResponse> Handle(LogonRequest request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, isPersistent:false, lockoutOnFailure:false);
            if (result.Succeeded){
                var token = _tokenService.GenerateToken(request.Email);
                return new UserResponse(token.Email, token.Token, token.Expiration);
            }
            return new UserResponse(400, "Email or passWord Invalid");
        }

        #endregion
        
        #region registerUserHandler
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

        #endregion
    }
}