using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApi.netcore.Helpers
{
    public class Common
    {
        public static string ConvertToSlug(string name)
        {
            return name.Replace(" ", "_");
        }
    }
}
