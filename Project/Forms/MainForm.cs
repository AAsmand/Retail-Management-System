using Framework.IOC;
using Project.Forms.User;
using Project.Models.User;
using Project.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class MainForm : Form
    {
        ManageItem manageItem;
        ManageUsers manageUsers;
        ManageBuyInvoice manageBuyInvoice;
        ManageSellInvoice manageSellInvoice;
        public MainForm(ManageItem manageItem, ManageUsers manageUsers, ManageBuyInvoice manageBuyInvoice, ManageSellInvoice manageSellInvoice)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.LayoutMdi(MdiLayout.TileHorizontal);
            this.manageItem = manageItem;
            this.manageUsers = manageUsers;
            this.manageBuyInvoice = manageBuyInvoice;
            this.manageSellInvoice = manageSellInvoice;
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            manageItem.MdiParent = this;
            manageItem.Show();
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        private void ConfigureAccess()
        {
            if (!UserModel.HasPermission(Access.ManageItem))
                ProductButton.Visible = false;
            if (!UserModel.HasPermission(Access.ManageBuyFactor))
                FactorButton.Visible = false;
            if (!UserModel.HasPermission(Access.ManageSellFactor))
                ManageSellInvoiceBtn.Visible = false;
            if (!UserModel.HasPermission(Access.ManageUser))
                ManageUsersBtn.Visible = false;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            UserDetalisLabel.Text = UserModel.Name + " " + UserModel.LastName;
            ConfigureAccess();
        }

        private void FactorButton_Click(object sender, EventArgs e)
        {
            manageBuyInvoice.MdiParent = this;
            manageBuyInvoice.Show();
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void ManageSellInvoiceBtn_Click(object sender, EventArgs e)
        {
            manageSellInvoice.MdiParent = this;
            manageSellInvoice.Show();
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void ManageUsersBtn_Click(object sender, EventArgs e)
        {
            manageUsers.MdiParent = this;
            manageUsers.Show();
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
