using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApi.netcore.Models.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Updated { get; set; }
        public bool Published { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
