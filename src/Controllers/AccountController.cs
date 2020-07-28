using System.Threading.Tasks;
using justauth.src.Domain.Commands.Requests;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace justauth.src.Controllers 
{
    [ApiController]
    [Route("v1/account")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest command)
        {
            if(!ModelState.IsValid){
                return StatusCode(400, ModelState);
            }
           var response =  await _mediator.Send(command);
           return response.StatusCode == 0 ? (IActionResult) Ok(response) : StatusCode(400, new {response.Errors, response	.Status}) ; 
        }

        [HttpPost("logon")]
        public async Task<IActionResult> Logon([FromBody] LogonRequest command)
        {
            if(!ModelState.IsValid){
                return StatusCode(400, ModelState);
            }
            var response =  await _mediator.Send(command);
            return response.StatusCode == 0 ? (IActionResult) Ok(response) : StatusCode(400, new {response.Errors, response	.Status}) ;  
        }
    }
}