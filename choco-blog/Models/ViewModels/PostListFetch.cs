using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApi.netcore.Models.ViewModels
{
    public class PostListFetch
    {
        public int PageNumber { get; set; }
        public int DisplayRecords { get; set; }
    }
}
