using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Models.User
{
    public static class UserModel
    {
        public static int UserId { get; set; }
        public static string Name { get; set; }
        public static string LastName { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static DateTime Birthday { get; set; }
        public static bool IsActive { get; set; }
        public static string Avatar { get; set; }
        public static bool IsDeleted { get; set; }
        public static List<int> PermissionsId { get; set; }   
        //public static List<PermissionModel> Permissions { get; set; }
        public static bool HasPermission(int permissionId)
        {
            //foreach (RoleModel item in Roles)
            //{
            //    if (item.Permissions.Any(p => p.PermissionId == permissionId))
            //        return true;
            //}
            if (PermissionsId.Any(p => p == permissionId))
                return true;
            return false;
        }

    }
}
