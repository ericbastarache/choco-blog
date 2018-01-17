using System;
using System.Linq;
using System.Threading.Tasks;
using JwtApi.netcore.Data;
using JwtApi.netcore.Helpers;
using JwtApi.netcore.Models;
using JwtApi.netcore.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.netcore.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public JsonResult All()
        {
            return Json(PostDAL.GetAllPosts());
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public JsonResult All(PostListFetch model)
        {
            return Json(PostDAL.GetAllPaginatedPosts(model));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public JsonResult GetPost(string id)
        {
            return Json(PostDAL.GetPost(id));
        }

        [Authorize(Roles = "Blogger")]
        [HttpPost("create")]
        public async Task<IActionResult> CreatePost(PostModel model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            PostDAL.CreatePost(model, user);

            return new OkResult();
        }

        [Authorize(Roles = "Blogger")]
        [HttpPut("edit")]
        public IActionResult EditPost(PostModel model)
        {
            PostDAL.EditPost(model);
            return new OkResult();
        }

        [Authorize(Roles = "Admin, Blogger")]
        [HttpDelete("discard")]
        public IActionResult RemovePost(PostModel model)
        {
            PostDAL.RemovePost(model);
            return new OkResult();
        }

        [HttpGet("addComment")]
        public async Task<IActionResult> AddComment(CommentModel model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            PostDAL.AddComment(model, user);

            return new OkResult();
        }

        [Authorize(Roles = "Admin, Blogger, Moderator")]
        [HttpDelete("removeComment")]
        public IActionResult RemoveComment(CommentModel model)
        {
            PostDAL.RemoveComment(model);
            return new OkResult();
        }

        [Authorize(Roles = "Moderator")]
        [HttpDelete("markRemove")]
        public IActionResult RemoveComment(int id)
        {
            PostDAL.MarkPostForRemoval(id);
            return new OkResult();
        }
    }
}