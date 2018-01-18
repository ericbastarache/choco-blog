using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApi.netcore.Models.RequesModels
{
    public class CommentRequestModel
    {
        public string Content { get; set; }
        public int PostId { get; set; }
    }
}
