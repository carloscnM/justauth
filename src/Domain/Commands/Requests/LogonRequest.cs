using System.ComponentModel.DataAnnotations;
using justauth.src.Domain.Commands.Responses;
using MediatR;

namespace justauth.src.Domain.Commands.Requests
{
    public class LogonRequest : IRequest<UserResponse>
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}