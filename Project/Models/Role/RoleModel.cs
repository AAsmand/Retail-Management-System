using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Models.Role
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }
        public List<PermissionModel> Permissions { get; set; } 
    }
}
