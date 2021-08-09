using Framework.IOC;
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
    public partial class ManageBuyInvoice : Form
    {
        IBuyInvoiceBusiness buyInvoiceBusiness;
        public ManageBuyInvoice(IBuyInvoiceBusiness buyInvoiceBusiness)
        {
            InitializeComponent();
            this.buyInvoiceBusiness = buyInvoiceBusiness;
        }
        private void ConfigureAccess()
        {
            if (!UserModel.HasPermission(Access.AddBuyFactor))
                AddBtnTool.Visible = false;
            if (!UserModel.HasPermission(Access.DeleteBuyFactor))
                DeleteBtnTool.Visible = false;
            if (!UserModel.HasPermission(Access.EditBuyFactor))
                EditBtnTool.Visible = false;
        }
        private void ManageBuyInvoice_Load(object sender, EventArgs e)
        {
            BindBuyInvoiceData();
            ConfigureAccess();
        }
        private void AddBtnTool_Click(object sender, EventArgs e)
        {
            AddBuyInvoice addBuyInvoice = IOC.Container.GetInstance<AddBuyInvoice>();
            addBuyInvoice.AddedEvent += RefreshBtn_Click;
            addBuyInvoice.MdiParent = this.MdiParent;
            addBuyInvoice.Show();
            addBuyInvoice.MdiParent.LayoutMdi(MdiLayout.TileVertical);
        }
        public void BindBuyInvoiceData()
        {
            BuyInvoiceGridView.AutoGenerateColumns = false;
            BuyInvoiceGridView.DataSource = null;
            BuyInvoiceGridView.DataSource = buyInvoiceBusiness.GetBuyInvoices();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            BindBuyInvoiceData();
        }

        private void DeleteBtnTool_Click(object sender, EventArgs e)
        {
            BuyInvoiceGridView.EndEdit();
            try
            {
                List<string> BuyInvoicesId = BuyInvoiceGridView.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Check"].Value != null).Where(r => int.Parse(r.Cells["Check"].Value.ToString()) == 1).Select(r => r.Cells["BuyInvoiceId"].Value.ToString()).ToList();
                if (BuyInvoicesId.Count == 0)
                    MessageBox.Show("هیچ سطری انتخاب نشده است", "خطا");
                else if (MessageBox.Show("آیا از حذف " + BuyInvoicesId.Count + "فاکتور مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    if (buyInvoiceBusiness.RemoveBuyInvoices(BuyInvoicesId))
                    {
                        BindBuyInvoiceData();
                        MessageBox.Show("عملیات با موفقیت انجام شد !", "موفق");
                    }
                    else
                        MessageBox.Show("عملیات با شکست مواجه شد ! موجودی انبار کافی نیست", "ناموفق");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("عملیات با شکست مواجه شد !", "ناموفق");
            }
        }
    }
}
