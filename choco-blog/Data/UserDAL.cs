using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtApi.netcore.Helpers;

namespace JwtApi.netcore.Data
{
    public class UserDAL
    {
        public static string[] GetRoles(string userId)
        {
            using (var ctx = new AppDbContext())
            {
                return (from ur in ctx.UserRoles
                    join r in ctx.Roles on ur.RoleId equals r.Id
                    where ur.UserId == userId
                    select r.Name).ToArray();
            }
        }
    }
}
