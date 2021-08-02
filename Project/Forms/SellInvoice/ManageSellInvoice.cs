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
        SellInvoiceItemRepository sellInvoiceItemRepository;
        StockItemRepository stockItemRepository;
        SellInvoiceRepository sellInvoiceRepository;
        public ManageSellInvoice()
        {
            InitializeComponent();
            sellInvoiceItemRepository = new SellInvoiceItemRepository();
            stockItemRepository = new StockItemRepository();
            sellInvoiceRepository = new SellInvoiceRepository();
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
            SellInvoiceGridView.DataSource = sellInvoiceRepository.GetData();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            BindSellInvoiceData();
        }

        private void DeleteBtnTool_Click(object sender, EventArgs e)
        {
            SellInvoiceGridView.EndEdit();
            bool isSuccess = false;
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    List<DataGridViewRow> list2 = SellInvoiceGridView.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Check"].Value != null).Where(r => int.Parse(r.Cells["Check"].Value.ToString()) == 1).ToList();
                    if (list2.Count == 0)
                        MessageBox.Show("هیچ سطری انتخاب نشده است", "خطا");
                    else if (MessageBox.Show("آیا از حذف " + list2.Count + "فاکتور مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        foreach (DataGridViewRow row in list2)
                        {
                            List<SellInvoiceItemModel> listItem = sellInvoiceItemRepository.GetSellInvoiceItems((int)row.Cells["SellInvoiceId"].Value);
                            foreach (SellInvoiceItemModel item in listItem)
                            {
                                stockItemRepository.UpdateStockItem(item.StockRoomId,item.ItemId,item.TracingFactor, item.Quantity);
                            }
                            sellInvoiceItemRepository.RemoveBuyInvoiceItems((int)row.Cells["SellInvoiceId"].Value);
                            sellInvoiceRepository.DeleteItem((int)row.Cells["SellInvoiceId"].Value);
                        }
                        transaction.Complete();
                        MessageBox.Show("عملیات با موفقیت انجام شد !", "موفق");
                        isSuccess = true;

                    }
                }
                catch (Exception exp)
                {
                    transaction.Dispose();
                    MessageBox.Show("عملیات با شکست مواجه شد !", "ناموفق");
                }
            }
            if (isSuccess)
                BindSellInvoiceData();
        }
    }
}
