using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JwtApi.netcore.Data;
using JwtApi.netcore.Helpers;
using JwtApi.netcore.Models;
using JwtApi.netcore.Models.RequesModels;
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
        [HttpGet("all2")]
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

        [HttpPost("create")]
        public IActionResult CreatePost([FromBody] PostRequestModel model)
        {
            var permissions = Permissions.ForPosts(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!permissions.Contains(Permissions.PostPermissions.Create))
            {
                return Unauthorized();
            }

            var user = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            PostDAL.CreatePost(model, user);

            return new OkResult();
        }

        [HttpPut("edit")]
        public IActionResult EditPost(PostModel model)
        {
            var permissions = Permissions.ForPosts(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!permissions.Contains(Permissions.PostPermissions.Update))
            {
                return Unauthorized();
            }

            PostDAL.EditPost(model);
            return new OkResult();
        }

        [HttpDelete("discard")]
        public IActionResult RemovePost(PostModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var isOwnPost = model.UserId == userId;
            var permissions = Permissions.ForPosts(userId);
            if (isOwnPost && !permissions.Contains(Permissions.PostPermissions.DeleteOwn) || 
                !isOwnPost && !permissions.Contains(Permissions.PostPermissions.DeleteOthers))
            {
                return Unauthorized();
            }

            PostDAL.RemovePost(model);
            return new OkResult();
        }

        [HttpPost("addComment")]
        public IActionResult AddComment([FromBody] CommentRequestModel model)
        {
            var user = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            PostDAL.AddComment(model, user);

            return new OkResult();
        }

        [HttpDelete("removeComment")]
        public IActionResult RemoveComment(CommentModel model)
        {
            var permissions = Permissions.ForComments(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!permissions.Contains(Permissions.CommentPermissions.Delete))
            {
                return Unauthorized();
            }

            PostDAL.RemoveComment(model);
            return new OkResult();
        }

        [HttpDelete("markRemove")]
        public IActionResult RemoveComment(int id)
        {
            var permissions = Permissions.ForComments(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!permissions.Contains(Permissions.CommentPermissions.MarkForDelete))
            {
                return Unauthorized();
            }

            PostDAL.MarkPostForRemoval(id);
            return new OkResult();
        }
    }
}