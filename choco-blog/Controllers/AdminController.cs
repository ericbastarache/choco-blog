using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JwtApi.netcore.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace choco_blog.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        [HttpGet("")]
        public IActionResult AdminAuth()
        {
            var permissions = Permissions.ForAdmin(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!permissions.Contains(Permissions.AdminPermissions.Access))
            {
                return Unauthorized();
            }

            return new OkResult();
        }
    }
}