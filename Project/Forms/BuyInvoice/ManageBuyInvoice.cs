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
        BuyInvoiceItemRepository buyInvoiceItemRepository;
        StockItemRepository stockItemRepository;
        BuyInvoiceRepository buyInvoiceRepository;
        public ManageBuyInvoice()
        {
            InitializeComponent();
            buyInvoiceItemRepository = new BuyInvoiceItemRepository();
            stockItemRepository = new StockItemRepository();
            buyInvoiceRepository = new BuyInvoiceRepository();
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
            AddBuyInvoice addBuyInvoice = new AddBuyInvoice();
            addBuyInvoice.AddedEvent += RefreshBtn_Click;
            addBuyInvoice.MdiParent = this.MdiParent;
            addBuyInvoice.Show();
            addBuyInvoice.MdiParent.LayoutMdi(MdiLayout.TileVertical);
        }
        public void BindBuyInvoiceData()
        {
            BuyInvoiceGridView.AutoGenerateColumns = false;
            BuyInvoiceGridView.DataSource = null;
            BuyInvoiceGridView.DataSource = buyInvoiceRepository.GetData();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            BindBuyInvoiceData();
        }

        private void DeleteBtnTool_Click(object sender, EventArgs e)
        {
            BuyInvoiceGridView.EndEdit();
            bool isSuccess = false;
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    List<DataGridViewRow> list2 = BuyInvoiceGridView.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Check"].Value != null).Where(r => int.Parse(r.Cells["Check"].Value.ToString()) == 1).ToList();
                    if (list2.Count == 0)
                        MessageBox.Show("هیچ سطری انتخاب نشده است", "خطا");
                    else if (MessageBox.Show("آیا از حذف " + list2.Count + "فاکتور مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        foreach (DataGridViewRow row in list2)
                        {
                            List<BuyInvoiceItemModel> listItem = buyInvoiceItemRepository.GetBuyInvoiceItems((int)row.Cells["BuyInvoiceId"].Value);
                            foreach (BuyInvoiceItemModel item in listItem)
                            {
                                stockItemRepository.UpdateStockItem(item.StockItemId, item.Quantity * -1);
                            }
                            buyInvoiceItemRepository.RemoveBuyInvoiceItems((int)row.Cells["BuyInvoiceId"].Value);
                            buyInvoiceRepository.DeleteItem((int)row.Cells["BuyInvoiceId"].Value);
                        }
                        transaction.Complete();
                        MessageBox.Show("عملیات با موفقیت انجام شد !", "موفق");
                        isSuccess = true;

                    }
                }
                catch (Exception)
                {
                    transaction.Dispose();
                    MessageBox.Show("عملیات با شکست مواجه شد !", "ناموفق");
                }
            }
            if (isSuccess)
                BindBuyInvoiceData();
        }
    }
}
