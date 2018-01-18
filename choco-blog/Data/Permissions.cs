using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JwtApi.netcore.Data
{
    public class Permissions
    {
        public static IList<AdminPermissions> ForAdmin(string userId)
        {
            var roles = UserDAL.GetRoles(userId);
            var permissions = new List<AdminPermissions>();

            if (roles.Contains("Admin"))
            {
                permissions.Add(AdminPermissions.Access);
            }

            return permissions;
        }

        public static IList<DashboardPermissions> ForDashboard(string userId)
        {
            var roles = UserDAL.GetRoles(userId);
            var permissions = new List<DashboardPermissions>();

            if (roles.Contains("Moderator") || roles.Contains("Blogger") || roles.Contains("Admin"))
            {
                permissions.Add(DashboardPermissions.Access);
            }

            if (roles.Contains("Admin"))
            {
                permissions.Add(DashboardPermissions.ViewAdminLink);
            }

            return permissions;
        }

        public static IList<CommentPermissions> ForComments(string userId)
        {
            var roles = UserDAL.GetRoles(userId);
            var permissions = new List<CommentPermissions>();

            if (roles.Contains("Moderator") || roles.Contains("Admin"))
            {
                permissions.Add(CommentPermissions.Delete);
                permissions.Add(CommentPermissions.Update);
            }

            if (roles.Contains("Blogger"))
            {
                permissions.Add(CommentPermissions.MarkForDelete);
            }

            return permissions;
        }

        public static IList<PostPermissions> ForPosts(string userId)
        {
            var roles = UserDAL.GetRoles(userId);
            var permissions = new List<PostPermissions>();

            if (roles.Contains("Moderator"))
            {
                permissions.Add(PostPermissions.MarkForDelete);
            }

            if (roles.Contains("Admin"))
            {
                permissions.Add(PostPermissions.DeleteOthers);
            }

            if (roles.Contains("Blogger"))
            {
                permissions.Add(PostPermissions.Create);
                permissions.Add(PostPermissions.Update);
                permissions.Add(PostPermissions.DeleteOwn);
            }

            return permissions;
        }

        #region Enums

        public enum PostPermissions
        {
            Create,
            Update,
            DeleteOwn,
            DeleteOthers,
            MarkForDelete
        }

        public enum CommentPermissions
        {
            Update,
            Delete,
            MarkForDelete
        }

        public enum DashboardPermissions
        {
            Access,
            ViewAdminLink
        }

        public enum AdminPermissions
        {
            Access
        }
        #endregion
    }
}
