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
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void ProductButton_Click(object sender, EventArgs e)
        {
            ManageItem manageItem = IOC.Container.GetInstance<ManageItem>();
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
            ManageBuyInvoice manageBuyInvoice = IOC.Container.GetInstance<ManageBuyInvoice>();
            manageBuyInvoice.MdiParent = this;
            manageBuyInvoice.Show();
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void ManageSellInvoiceBtn_Click(object sender, EventArgs e)
        {
            ManageSellInvoice manageSellInvoice = IOC.Container.GetInstance<ManageSellInvoice>();
            manageSellInvoice.MdiParent = this;
            manageSellInvoice.Show();
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void ManageUsersBtn_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers = IOC.Container.GetInstance<ManageUsers>();
            manageUsers.MdiParent = this;
            manageUsers.Show();
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
