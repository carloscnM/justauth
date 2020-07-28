using Microsoft.AspNetCore.Mvc;

namespace justauth.src.Controllers 
{
    [ApiController]
    [Route("v1/roles")]
    public class RolesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Index()
        {            
            return Ok("ok");
        }

        [HttpGet("{roleName}")]
        public IActionResult Show(string roleName)
        {
            return Ok(roleName);
        }

        [HttpPost]
        public IActionResult Create(string roleName)
        {
            return Ok(roleName);
        }
        
        [HttpPut]
        public IActionResult Update(string roleName)
        {
            return Ok(roleName);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return NotFound();
        }


    }
}