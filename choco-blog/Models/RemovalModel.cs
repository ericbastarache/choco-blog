using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace JwtApi.netcore.Models
{
    public class RemovalModel
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public bool Removed { get; set; } = false;
    }
}
