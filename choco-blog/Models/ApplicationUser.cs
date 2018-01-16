using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApi.netcore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [InverseProperty("User")]
        public List<PostModel> Posts { get; set; }
        [InverseProperty("User")]
        public List<CommentModel> Comments { get; set; }
    }
}
