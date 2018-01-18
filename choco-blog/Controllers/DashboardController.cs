using System.Security.Claims;
using JwtApi.netcore.Data;
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
        [HttpGet("")]
        public IActionResult DashboardAuth()
        {
            var permissions = Permissions.ForDashboard(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!permissions.Contains(Permissions.DashboardPermissions.Access))
            {
                return Unauthorized();
            }
            
            return new OkResult();
        }
    }
}