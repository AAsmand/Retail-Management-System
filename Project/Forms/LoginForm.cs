using Framework.IOC;
using Project.Business;
using Project.Models.Role;
using Project.Models.User;
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
        IUserBusiness userBusiness;
        public LoginForm(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(userBusiness.Login(UserTxt.Text,PassTxt.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("ورود با موفقیت انجام شد", "موفق", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("چنین کاربری در سیستم وجود ندارد", "خطا", MessageBoxButtons.OK);
                }
            }
            catch(Exception exp)
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}
