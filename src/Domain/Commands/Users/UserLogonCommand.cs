using System.ComponentModel.DataAnnotations;
using justauth.src.Models.Responses.Users;
using MediatR;

namespace justauth.src.Domain.Commands.Users
{
    public class UserLogonCommand : IRequest<UserResponse>
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}