using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApi.netcore.Models.RequesModels
{
    public class PostRequestModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool Published { get; set; }
    }
}
