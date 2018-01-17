using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtApi.netcore.Helpers;
using JwtApi.netcore.Models;
using JwtApi.netcore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.netcore.Data
{
    public class PostDAL
    {
        public static IList<PostViewModel> GetAllPosts()
        {
            using (var ctx = new AppDbContext()) {
            
                var posts = ctx.Posts.Where(x => x.Published)
                    .Select(x => new PostViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Slug = x.Slug,
                        Content = x.Content,
                        UpdatedDate = x.UpdatedDate,
                        Updated = x.Updated,
                        Published = x.Published,
                        UserId = x.UserId,
                        UserName = ctx.Users.SingleOrDefault(u => u.Id == x.UserId).UserName
                    }).ToList();

                return posts;
            }
        }

        public static PostListCart GetAllPaginatedPosts(PostListFetch model)
        {
            var postCart = new PostListCart();
            var skip = model.PageNumber - 1;
            skip *= model.DisplayRecords;

            using (var ctx = new AppDbContext())
            {
                var postCount = ctx.Posts.Count(x => x.Published);

                var posts = ctx.Posts.Where(x => x.Published)
                    .Where(x => x.Published)
                    .Skip(skip)
                    .Take(model.DisplayRecords)
                    .Select(x => new PostViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Slug = x.Slug,
                        Content = x.Content,
                        UpdatedDate = x.UpdatedDate,
                        Updated = x.Updated,
                        Published = x.Published,
                        UserId = x.UserId,
                        UserName = ctx.Users.SingleOrDefault(u => u.Id == x.UserId).UserName
                    }).ToList();

                postCart.TotalPosts = postCount;
                postCart.TotalPosts = ((postCount + model.DisplayRecords - 1) / model.DisplayRecords);
                postCart.CurrentPage = model.PageNumber;
                postCart.Posts = posts;
            }

            return postCart;
        }

        public static object GetPost(string id)
        {
            var isNumber = int.TryParse(id, out var identifier);
            PostViewModel post;

            using (var ctx = new AppDbContext())
            {
                if (isNumber)
                {
                    post = ctx.Posts.Select(x => new PostViewModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Slug = x.Slug,
                            Content = x.Content,
                            UpdatedDate = x.UpdatedDate,
                            Updated = x.Updated,
                            Published = x.Published,
                            UserId = x.UserId,
                            UserName = ctx.Users.SingleOrDefault(u => u.Id == x.UserId).UserName
                    }).SingleOrDefault(x => x.Id == identifier);
                }
                else
                {
                    post = ctx.Posts.Select(x => new PostViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Slug = x.Slug,
                        Content = x.Content,
                        UpdatedDate = x.UpdatedDate,
                        Updated = x.Updated,
                        Published = x.Published,
                        UserId = x.UserId,
                        UserName = ctx.Users.SingleOrDefault(u => u.Id == x.UserId).UserName
                    }).SingleOrDefault(x => x.Slug == id);
                }

                var comments = ctx.Comments.Where(x => x.PostId == post.Id)
                    .Select(x => new CommentViewModel
                    {
                        Id = x.Id,
                        Content = x.Content,
                        Created = x.Created,
                        UserId = x.UserId,
                        PostId = x.PostId,
                        UserName = ctx.Users.SingleOrDefault(u => u.Id == x.UserId).UserName,
                        PostName = ctx.Posts.SingleOrDefault(p => p.Id == x.PostId).Name
                    }).ToList();

                return new
                {
                    post = post,
                    comments = comments
                };
            }
        }

        public static void CreatePost(PostModel model, ApplicationUser user)
        {
            model.Slug = Common.ConvertToSlug(model.Name);
            model.UpdatedDate = DateTime.Now;
            model.Updated = false;
            model.UserId = user.Id;

            using (var ctx = new AppDbContext())
            {
                ctx.Posts.Add(model);
                ctx.SaveChanges();
            }
        }

        public static void EditPost(PostModel model)
        {
            using (var ctx = new AppDbContext())
            {
                ctx.Entry(model).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public static void RemovePost(PostModel model)
        {
            using (var ctx = new AppDbContext())
            {
                ctx.Entry(model).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public static void AddComment(CommentModel model, ApplicationUser user)
        {
            model.UserId = user.Id;
            model.Created = DateTime.Now;

            using (var ctx = new AppDbContext())
            {
                ctx.Add(model);
                ctx.SaveChanges();
            }
        }

        public static void RemoveComment (CommentModel model)
        {
            using (var ctx = new AppDbContext())
            {
                ctx.Entry(model).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public static void MarkPostForRemoval(int id)
        {
            using (var ctx = new AppDbContext())
            {
                var model = new RemovalModel
                {
                    PostId = id
                };

                ctx.PostRemovals.Add(model);
                ctx.SaveChanges();
            }
        }
    }
}
