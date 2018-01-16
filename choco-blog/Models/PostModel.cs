using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace JwtApi.netcore.Models
{
    public class PostModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool Updated { get; set; } = false;
        public bool Published { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        
        [InverseProperty("Post")]
        public List<CommentModel> Comments { get; set; }
    }
}
