using System.ComponentModel.DataAnnotations;
using justauth.src.Domain.Commands.Responses;
using MediatR;

namespace justauth.src.Domain.Commands.Requests
{
    public class CreateRolesRequest : IRequest<RolesResponse>
    {
        [Required]
        public string Name { get; set; }
    }
}