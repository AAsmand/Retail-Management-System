using Project.Models.Role;
using Project.Models.User;
using Project.Repositories.Role;
using Project.Repositories.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project.Forms.User
{
    public partial class LoginForm : Form
    {
        UserRepository userRepository;
        RoleRepository roleRepository;
        PermissionRepository permissionRepository;
        public LoginForm()
        {
            InitializeComponent();
            userRepository = new UserRepository();
            roleRepository = new RoleRepository();
            permissionRepository = new PermissionRepository();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable User = userRepository.LoginUser(UserTxt.Text, PassTxt.Text);
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
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("ورود با موفقیت انجام شد", "موفق", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("کاربری شما فعال نیست", "خطا", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("چنین کاربری در سیستم وجود ندارد", "خطا", MessageBoxButtons.OK);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("ارتباط با پایگاه داده با خطا مواجه شد", "خطا", MessageBoxButtons.OK);
            }

        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                LoginBtn_Click(this, new EventArgs());
            }
        }
    }
}
