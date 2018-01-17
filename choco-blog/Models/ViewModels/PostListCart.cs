using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApi.netcore.Models.ViewModels
{
    public class PostListCart
    {
        public int TotalPosts { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public List<PostViewModel> Posts { get; set; }
    }
}
