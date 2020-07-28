using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace justauth.src.Controllers 
{
    [ApiController]
    [Route("v1/check")]
    public class CheckAccessController : ControllerBase
    {
        [Authorize]
        public IActionResult CheckAcessToken()
        {            
            return Ok(new { Status = "Authorized", Email = User.Identity.Name});
        }
    }
}