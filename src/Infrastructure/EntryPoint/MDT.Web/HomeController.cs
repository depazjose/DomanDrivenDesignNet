using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;


namespace MDT.Web
{
  [Produces("application/json")]
  [Route("api/[controller]/[action]")]
  [EnableCors("AllowOrigin")]
  public class HomeController: ControllerBase
  {

  [HttpGet]
  [EnableCors("AllowOrigin")]
  public IActionResult GetFoo()
  {
    return Ok("Hello World");
  }

  }
}
