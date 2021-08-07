using Project.Models.Role;
using Project.Models.User;
using Project.Repositories.Role;
using Project.Repositories.User;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Project.Business
{
    public class UserBusiness:BaseBusiness<UserViewModel,UserRepository>, IUserBusiness
    {
        private RoleRepository roleRepository;
        private UserRepository userRepository;
        private PermissionRepository permissionRepository;
        public UserBusiness()
        {
            roleRepository = new RoleRepository();
            userRepository = new UserRepository();
            permissionRepository = new PermissionRepository();
        }
        public bool Login(string username, string password)
        {
            DataTable User = userRepository.LoginUser(username, password);
            if (User.Rows.Count == 1)
            {
                UserModel.UserId = (int)User.Rows[0]["UserId"];
                UserModel.Name = User.Rows[0]["Name"].ToString();
                UserModel.LastName = User.Rows[0]["LastName"].ToString();
                UserModel.Username = User.Rows[0]["Username"].ToString();
                UserModel.Password = User.Rows[0]["Password"].ToString();
                UserModel.Birthday = DateTime.Parse(User.Rows[0]["Birthday"].ToString());
                UserModel.IsActive = (bool)User.Rows[0]["IsActive"];
                UserModel.IsDeleted = (bool)User.Rows[0]["IsDeleted"];
                UserModel.Avatar = User.Rows[0]["Avatar"].ToString();
                if (UserModel.IsActive && !UserModel.IsDeleted)
                {
                    DataTable Roles = roleRepository.GetUserRoles(UserModel.UserId);
                    UserModel.Roles = Roles.Rows.Cast<DataRow>().Select(r => new RoleModel() { RoleId = (int)r["RoleId"], RoleName = r["RoleName"].ToString(), IsDeleted = (bool)r["IsDeleted"], Permissions = permissionRepository.GetRolesPermissions((int)r["RoleId"]).Rows.Cast<DataRow>().Select(p => new PermissionModel() { PermissionId = (int)p["PermissionId"], Name = p["Name"].ToString(), ParentId = p["ParentId"] != DBNull.Value ? (int)p["ParentId"] : 0, Description = p["Description"].ToString() }).ToList() }).ToList();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public List<RoleViewModel> GetRole(string roleId)
        {
            return roleRepository.GetRoles(roleId).Rows.Cast<DataRow>().Select(r => new RoleViewModel() { RoleId = r["RoleId"].ToString(), RoleName = r["RoleName"].ToString() }).ToList();
        }
        public bool AddUser(UserViewModel model)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int userId = userRepository.AddUser(model);
                    if (userId > 0)
                    {
                        foreach (RoleViewModel item in model.Roles)
                        {
                            if (!roleRepository.AddUserRole(userId, int.Parse(item.RoleId)))
                            {
                                scope.Dispose();
                                return false;
                            }
                        }
                        scope.Complete();
                        return true;
                    }
                    scope.Dispose();
                    return false;
                }
            }
            catch (Exception) { return false; }
        }
        public bool RemoveUsers(List<int> users)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (int item in users)
                    {
                        userRepository.DeleteUser(item);
                    }
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public string UpdateUser(UserViewModel model)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                if (!IsValid(model))
                {
                    builder.AppendLine("اطلاعات کاربر تغییر کرده است لطفا مجددا وارد صفحه ویرایش شوید و دوباره تلاش کنید");
                    return builder.ToString();
                }
                using (TransactionScope scope = new TransactionScope())
                {
                    roleRepository.DeleteUserRoles(model.UserId);
                    foreach (RoleViewModel item in model.Roles)
                    {
                        if (!roleRepository.AddUserRole(model.UserId, int.Parse(item.RoleId)))
                        {
                            scope.Dispose();
                            builder.AppendLine("خطا در زمان آپدیت نقش های کاربر");
                            return builder.ToString();
                        }
                    }
                    if (userRepository.UpdateUser(model))
                    {
                        scope.Complete();
                        return "";
                    }
                    else
                    {
                        scope.Dispose();
                        builder.AppendLine("خطا در زمان آپدیت اطلاعات کاربر");
                        return builder.ToString();
                    }
                }
            }
            catch (Exception exp) { return "خطا در زمان آپدیت کاربر"; }
        }
        public UserViewModel GetUser(int userId)
        {
            try
            {
                UserViewModel model = new UserViewModel();
                DataTable User = userRepository.GetUser(userId);
                if (User.Rows.Count == 1)
                {
                    model.UserId = (int)User.Rows[0]["UserId"];
                    model.Name = User.Rows[0]["Name"].ToString();
                    model.LastName = User.Rows[0]["LastName"].ToString();
                    model.Username = User.Rows[0]["Username"].ToString();
                    model.Password = User.Rows[0]["Password"].ToString();
                    model.Birthday = DateTime.Parse(User.Rows[0]["Birthday"].ToString());
                    model.IsActive = (bool)User.Rows[0]["IsActive"];
                    model.IsDeleted = (bool)User.Rows[0]["IsDeleted"];
                    model.Avatar = User.Rows[0]["Avatar"].ToString();
                    model.TimeStamp = (int)User.Rows[0]["TimeStamp"];
                    DataTable Roles = roleRepository.GetUserRoles(model.UserId);
                    model.Roles = Roles.Rows.Cast<DataRow>().Select(r => new RoleViewModel() { RoleId = r["RoleId"].ToString(), RoleName = r["RoleName"].ToString() }).ToList();
                    return model;
                }
                else
                    return null;
            }
            catch (Exception exp) { return null; }
        }
        public RoleViewModel GetRole(int roleId)
        {
            return roleRepository.GetRole(roleId).Rows.Cast<DataRow>().Select(r => new RoleViewModel() { RoleId = r["RoleId"].ToString(), RoleName = r["RoleName"].ToString() }).FirstOrDefault();
        }
        public DataTable GetUsers()
        {
            return userRepository.GetUsers();
        }
    }
}

