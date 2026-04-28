using Microsoft.AspNetCore.Mvc;

namespace DevOpsApi.Controllers
{
    [ApiController]
    [Route("api/time")]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var now = DateTimeOffset.Now;

            return Ok(new
            {
                time = now.ToString("O"),
                timezone = TimeZoneInfo.Local.StandardName
            });
        }
    }
}
