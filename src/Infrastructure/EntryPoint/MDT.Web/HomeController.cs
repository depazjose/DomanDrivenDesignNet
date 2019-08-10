using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Threading.Tasks;


namespace MDT.Web
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowOrigin")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetFoo(string foo)
        {
            return await Task.Run(() =>
            {
                var ret = new { foo = foo };
                return Ok(ret);
            });
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetFood()
        {
            return await Task.Run(() =>
            {
                var food = new { Food = "Burger" };
                return Ok(food);
            });
        }
    }
}
