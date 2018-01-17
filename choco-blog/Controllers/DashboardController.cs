using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.netcore.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        // api call to make sure we have access to the dashboard before we load
        [Authorize(Roles = "Admin, Blogger, Moderator")]
        [HttpGet("")]
        public IActionResult DashboardAuth()
        {
            return new OkResult();
        }
    }
}