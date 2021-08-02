using Project.Business;
using Project.Models;
using Project.Models.User;
using Project.Repositories;
using Project.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace Project
{
    public partial class ManageSellInvoice : Form
    {
        SellInvoiceBusiness sellInvoiceBusiness;
        public ManageSellInvoice()
        {
            InitializeComponent();
            sellInvoiceBusiness = new SellInvoiceBusiness();
        }
        private void ConfigureAccess()
        {
            if (!UserModel.HasPermission(Access.AddSellFactor))
                AddBtnTool.Visible = false;
            if (!UserModel.HasPermission(Access.DeleteSellFactor))
                DeleteBtnTool.Visible = false;
            if (!UserModel.HasPermission(Access.EditSellFactor))
                EditBtnTool.Visible = false;
        }
        private void ManageBuyInvoice_Load(object sender, EventArgs e)
        {
            BindSellInvoiceData();
            ConfigureAccess();
        }
        private void AddBtnTool_Click(object sender, EventArgs e)
        {
            AddSellInvoice addSellInvoice = new AddSellInvoice();
            addSellInvoice.AddedEvent += RefreshBtn_Click;
            addSellInvoice.MdiParent = this.MdiParent;
            addSellInvoice.Show();
            addSellInvoice.MdiParent.LayoutMdi(MdiLayout.TileVertical);
        }
        public void BindSellInvoiceData()
        {
            SellInvoiceGridView.AutoGenerateColumns = false;
            SellInvoiceGridView.DataSource = null;
            SellInvoiceGridView.DataSource = sellInvoiceBusiness.GetSellInvoices();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            BindSellInvoiceData();
        }

        private void DeleteBtnTool_Click(object sender, EventArgs e)
        {
            SellInvoiceGridView.EndEdit();
            try
            {
                List<string> selectedId = SellInvoiceGridView.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Check"].Value != null).Where(r => int.Parse(r.Cells["Check"].Value.ToString()) == 1).Select(r => r.Cells["SellInvoiceId"].ToString()).ToList();
                if (selectedId.Count == 0)
                    MessageBox.Show("هیچ سطری انتخاب نشده است", "خطا");
                else if (MessageBox.Show("آیا از حذف " + selectedId.Count + "فاکتور مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    sellInvoiceBusiness.RemoveBuyInvoices(selectedId);
                    MessageBox.Show("عملیات با موفقیت انجام شد !", "موفق");
                    BindSellInvoiceData();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("عملیات با شکست مواجه شد !", "ناموفق");
            }
                
        }
    }
}
