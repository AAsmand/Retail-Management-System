using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Models.Role
{
    public class PermissionModel
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }

    }
}
