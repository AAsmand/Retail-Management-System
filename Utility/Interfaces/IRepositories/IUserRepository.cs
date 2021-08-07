using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface IUserRepository:IBaseRepository
    {
        DataTable LoginUser(string username, string password);
        DataTable GetUser(int userId);
        DataTable GetUsers();
        int AddUser(UserViewModel model);
        bool DeleteUser(int userId);
        bool UpdateUser(UserViewModel user);
    }
}
