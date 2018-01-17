using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // api call to make sure we have access to the dashboard before we load
        [Authorize(Roles = "Admin")]
        [HttpGet("")]
        public IActionResult AdminAuth()
        {
            return new OkResult();
        }
    }
}