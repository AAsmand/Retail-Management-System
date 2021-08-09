using Framework;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public interface IUserBusiness:IConcurrencyChecker,IBase
    {
        bool Login(string username, string password);
        List<RoleViewModel> GetRole(string roleId);
        bool AddUser(UserViewModel model);

        bool RemoveUsers(List<int> users);

        string UpdateUser(UserViewModel model);
        UserViewModel GetUser(int userId);
        RoleViewModel GetRole(int roleId);
        DataTable GetUsers();
    }
}

