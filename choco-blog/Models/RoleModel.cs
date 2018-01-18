using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApi.netcore.Models
{
    public class RoleModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("Role")]
        public List<UserRolesModel> UserRoles { get; set; }
    }
}
