using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtApi.netcore.Data;
using JwtApi.netcore.Helpers;
using JwtApi.netcore.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace choco_blog.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsController(AppDbContext ctx, UserManager<ApplicationUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
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
            var post = isNumber ? _ctx.Posts.SingleOrDefault(x => x.Id == identifier)
                : _ctx.Posts.SingleOrDefault(x => x.Slug == id);

            var comments = _ctx.Comments.Where(x => x.PostId == post.Id);

            return Json(new
            {
                post = post,
                comments = comments
            });
        }

        [Authorize(Roles = "Admin, Blogger")]
        [HttpPost("create")]
        public async Task<JsonResult> CreatePost(PostModel model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            model.Slug = Common.ConvertToSlug(model.Name);
            model.UpdatedDate = DateTime.Now;
            model.Updated = false;
            model.UserId = user.Id;

            _ctx.Posts.Add(model);
            _ctx.SaveChanges();

            return Json(model);
        }
    }
}