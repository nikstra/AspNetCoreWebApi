using AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(Context.Foos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Foo foo)
        {
            if(foo == null)
            {
                return BadRequest();
            }

            Context.Foos.Add(foo);

            return new JsonResult(foo);
        }
    }
}