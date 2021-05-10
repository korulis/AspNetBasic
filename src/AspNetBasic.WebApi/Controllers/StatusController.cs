using System;
using Microsoft.AspNetCore.Mvc;

namespace AspNetBasic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult GetStatus()
        {
            return Ok($"Hello from AspNetBasic in {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}!");
        }
    }
}
