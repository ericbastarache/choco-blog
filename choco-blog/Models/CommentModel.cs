using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApi.netcore.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [ForeignKey("PostId")]
        public PostModel Post { get; set; }
    }
}
