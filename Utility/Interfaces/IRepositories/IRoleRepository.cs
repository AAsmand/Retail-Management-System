using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface IRoleRepository:IBaseRepository,IChooseRepository
    {
        DataTable GetUserRoles(int userId);
        DataTable GetRoles(string sameRoleId);
        bool AddUserRole(int userId, int roleId);
        bool DeleteUserRoles(int userId);
        DataTable GetRole(int roleId);
    }
}
