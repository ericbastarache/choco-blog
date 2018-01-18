using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace JwtApi.netcore.Models
{
    public class UserRolesModel
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserId { get; set; }

        [ForeignKey("RoleId")]
        public RoleModel Role { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
