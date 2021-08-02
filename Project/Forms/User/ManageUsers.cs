using Project.Business;
using Project.Models.User;
using Project.Repositories.User;
using Project.Tools;
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
    public partial class ManageUsers : Form
    {
        private UserRepository userRepository;
        private UserBusiness userBusiness;
        public ManageUsers()
        {
            InitializeComponent();
            userRepository = new UserRepository();
            userBusiness = new UserBusiness();
        }
        private void ConfigureAccess()
        {
            if (!UserModel.HasPermission(Access.AddUser))
                AddBtnTool.Visible = false;
            if (!UserModel.HasPermission(Access.DeleteUser))
                DeleteBtnTool.Visible = false;
            if (!UserModel.HasPermission(Access.EditUser))
                EditBtnTool.Visible = false;
            if (!UserModel.HasPermission(Access.ManageRole))
                ManageRolesBtn.Visible = false;
        }
        public void BindUserData()
        {
            UserGridView.AutoGenerateColumns = false;
            UserGridView.DataSource = null;
            UserGridView.DataSource = userRepository.GetUsers();
        }
        private void ManageUsers_Load(object sender, EventArgs e)
        {
            BindUserData();
            ConfigureAccess();
        }

        private void AddBtnTool_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.AddedEvent += RefreshBtn_Click;
            addUser.MdiParent = this.MdiParent;
            addUser.Show();
            addUser.MdiParent.LayoutMdi(MdiLayout.TileVertical);
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            BindUserData();
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void DeleteBtnTool_Click(object sender, EventArgs e)
        {
            UserGridView.EndEdit();
            List<DataGridViewRow> rows = UserGridView.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Check"].Value != null).ToList();
            if (MessageBox.Show("آیا از حذف " + rows.Count + " کاربر مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (userBusiness.RemoveUsers(rows.Select(r => (int)r.Cells["UserId"].Value).ToList()))
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفق");
                    BindUserData();
                }
                else
                    MessageBox.Show("عملیات با شکست مواجه شد", "ناموفق");
            }
        }

        private void EditBtnTool_Click(object sender, EventArgs e)
        {
            if (UserGridView.SelectedRows.Count == 1)
            {
                AddUser addUser = new AddUser((int)UserGridView.CurrentRow.Cells["UserId"].Value);
                addUser.AddedEvent += RefreshBtn_Click;
                addUser.MdiParent = this.MdiParent;
                addUser.Show();
                addUser.MdiParent.LayoutMdi(MdiLayout.TileVertical);
            }
            else
                MessageBox.Show("لطفا ابتدا یک کاربر را انتخاب نمایید", "خطا");
        }
    }
}
