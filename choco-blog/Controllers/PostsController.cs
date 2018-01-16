using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtApi.netcore.Data;
using JwtApi.netcore.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace choco_blog.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly AppDbContext _ctx;

        public PostsController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public JsonResult All()
        {
            return Json(_ctx.Posts.Where(x => x.Published));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public JsonResult GetPost(string id)
        {
            var isNumber = int.TryParse(id, out var identifier);
            return Json(isNumber ? _ctx.Posts.SingleOrDefault(x => x.Id == identifier) 
                : _ctx.Posts.SingleOrDefault(x => x.Slug == id));
        }
    }
}