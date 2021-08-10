using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface IRoleRepository:IBaseRepository
    {
        DataTable GetUserRoles(int userId);
        DataTable GetRolesByFilter(string sameRoleId);
        bool AddUserRole(int userId, int roleId);
        bool DeleteUserRoles(int userId);
        DataTable GetRole(int roleId);
    }
}
