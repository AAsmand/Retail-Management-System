using BusinessLayer.Business.BaseUIView;
using Project.Business;
using Project.Forms.Shared;
using Project.Models.Role;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project.Forms.User
{
    public partial class AddUser : Form
    {
        int _userId;
        UserViewModel user;
        public event EventHandler AddedEvent;
        private List<RoleViewModel> RoleList;
        private ChooseForm chooseRollForm;
        private UserBusiness userBusiness;
        public AddUser()
        {
            InitializeComponent();
            RoleList = new List<RoleViewModel>();
            userBusiness = new UserBusiness();
            UserErrorProvider.SetErrorWithCount(NameTxt, "وارد کردن فیلد نام اجباری است");
            UserErrorProvider.SetErrorWithCount(LastNameTxt, "وارد کردن فیلد نام خانوادگی اجباری است");
            UserErrorProvider.SetErrorWithCount(UsernameTxt, "وارد کردن فیلد نام کاربری اجباری است");
            UserErrorProvider.SetErrorWithCount(PasswordTxt, "وارد کردن فیلد کلمه عبور اجباری است");
        }
        public AddUser(int userId)
        {
            InitializeComponent();
            userBusiness = new UserBusiness();
            _userId = userId;
            user = userBusiness.GetUser(_userId);
            RoleList = user.Roles;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            RolesBindingSource.DataSource = RoleList;
            if (user != null)
            {
                PersianCalendar calendar = new PersianCalendar();
                string persianDate = calendar.GetYear(user.Birthday).ToString() + "/" + calendar.GetMonth(user.Birthday).ToString() + "/" + calendar.GetDayOfMonth(user.Birthday).ToString();
                RolesBindingSource.DataSource = user.Roles;
                NameTxt.Text = user.Name;
                LastNameTxt.Text = user.LastName;
                UsernameTxt.Text = user.Username;
                PasswordTxt.Text = user.Password;
                BirthdayTxt.Text = persianDate;
                IsActiveCheckBox.Checked = user.IsActive;
                PicAddressTxt.Text = user.Avatar;
                AddBtn.Text = "ویرایش";
                this.Text = "ویرایش کاربر" + user.Name + " " + user.LastName;
            }
            RolesNavigator.BindingSource = RolesBindingSource;
            RolesGridView.AutoGenerateColumns = false;
            RolesGridView.DataSource = RolesBindingSource;
        }
        public void OnAdded()
        {
            if (AddedEvent != null)
            {
                AddedEvent(this, new EventArgs());
                this.Close();
            }
        }
        private void RolesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == senderGrid.Columns["SelectRoleBtn"].Index &&
                e.RowIndex >= 0)
            {
                RolesGridView.EndEdit();
                if (e.ColumnIndex == RolesGridView.Columns["SelectRoleBtn"].Index)
                {
                    object o = RolesGridView.Rows[e.RowIndex].Cells["RoleId"].Value;
                    chooseRollForm = new ChooseForm(new RoleUiView(RoleList, RolesGridView.Rows[e.RowIndex].Cells["RoleId"].Value != null ? (int)RolesGridView.Rows[e.RowIndex].Cells["RoleId"].Value : 0));
                    chooseRollForm.MdiParent = this.MdiParent;
                    chooseRollForm.ControlBox = false;
                    chooseRollForm.FormBorderStyle = FormBorderStyle.None;
                    chooseRollForm.Selected += RoleSelected;
                    chooseRollForm.Show();
                }
            }
        }
        private void RoleSelected(object sender, SelectEventArgs args)
        {
            if (RoleList.Any(r => r.RoleId == args.Id.ToString()))
            {
                MessageBox.Show("این نقش پیش ازین انتخاب شده است", "خطا");
                RolesGridView.Rows.Remove(RolesGridView.CurrentRow);
            }
            else
            {
                RolesGridView.CurrentRow.Cells["RoleId"].Value = args.Id.ToString();
                RolesGridView.CurrentRow.Cells["RoleName"].Value = userBusiness.GetRole(args.Id).RoleName;
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UserErrorProvider.HasErrors())
                {
                    PersianCalendar persianCalendar = new PersianCalendar();
                    string[] persianDate = BirthdayTxt.Text.Split('/');
                    DateTime persianDateTime = persianCalendar.ToDateTime(Convert.ToInt32(persianDate[0]), Convert.ToInt32(persianDate[1]), Convert.ToInt32(persianDate[2]), 0, 0, 0, 0);
                    UserViewModel model = new UserViewModel();
                    model.Name = NameTxt.Text;
                    model.LastName = LastNameTxt.Text;
                    model.Username = UsernameTxt.Text;
                    model.Password = PasswordTxt.Text;
                    model.Birthday = persianDateTime;
                    model.IsActive = IsActiveCheckBox.Checked;
                    model.Avatar = PicAddressTxt.Text;
                    model.Roles = RoleList.Select(r => new RoleViewModel() { RoleId = r.RoleId }).ToList();
                    model.TimeStamp = user.TimeStamp;
                    if (user == null)
                    {
                        if (userBusiness.AddUser(model))
                        {
                            MessageBox.Show("عملیات با موفقیت انجام شد", "موفق");
                            OnAdded();
                        }
                        else MessageBox.Show("عملیات با شکست مواجه شد", "ناموفق");
                    }
                    else
                    {
                        model.UserId = user.UserId;
                        string message = userBusiness.UpdateUser(model);
                        if (message=="")
                        {
                            MessageBox.Show("عملیات با موفقیت انجام شد", "موفق");
                            OnAdded();
                        }
                        else MessageBox.Show(message, "ناموفق");
                    }
                }
                else
                    MessageBox.Show("لطفا ابتدا خطاهای مربوطه را برطرف نمایید", "خطا");
            }
            catch (Exception)
            {
                MessageBox.Show("عملیات با شکست مواجه شد", "ناموفق");
            }
        }

        #region Validation
        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(NameTxt.Text))
                UserErrorProvider.SetErrorWithCount(NameTxt, "وارد کردن فیلد نام اجباری است");
            else
                UserErrorProvider.SetErrorWithCount(NameTxt, "");
        }

        private void LastNameTxt_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(LastNameTxt.Text))
                UserErrorProvider.SetErrorWithCount(LastNameTxt, "وارد کردن فیلد نام خانوادگی اجباری است");
            else
                UserErrorProvider.SetErrorWithCount(LastNameTxt, "");
        }

        private void UsernameTxt_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UsernameTxt.Text))
                UserErrorProvider.SetErrorWithCount(UsernameTxt, "وارد کردن فیلد نام کاربری اجباری است");
            else
                UserErrorProvider.SetErrorWithCount(UsernameTxt, "");
        }
        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(PasswordTxt.Text))
                UserErrorProvider.SetErrorWithCount(PasswordTxt, "وارد کردن فیلد کلمه عبور اجباری است");
            else
                UserErrorProvider.SetErrorWithCount(PasswordTxt, "");
        }
        #endregion
    }
    public static class ErrorProviderExtensions
    {
        private static int count;

        public static void SetErrorWithCount(this ErrorProvider ep, Control c, string message)
        {
            if (message == "")
            {
                if (ep.GetError(c) != "")
                    count--;
            }
            else
               if (ep.GetError(c) == "")
                count++;

            ep.SetError(c, message);
        }

        public static bool HasErrors(this ErrorProvider ep)
        {
            return count != 0;
        }

        public static int GetErrorCount(this ErrorProvider ep)
        {
            return count;
        }
    }
}



