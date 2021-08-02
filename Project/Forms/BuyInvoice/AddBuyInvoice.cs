﻿using Project.Repositories;
using Project.Repositories.TypedData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Project.Models;
using System.Transactions;

namespace Project
{
    public partial class AddBuyInvoice : Form
    {
        public event EventHandler AddedEvent;
        private BuyInvoiceItemDataTable dataTable;
        private ChooseItemForm itemForm;
        private ChooseStockRoomForm stockRoomForm;
        private StockItemRepository stockItemRepository;
        private BuyInvoiceItemRepository buyInvoiceItemRepository;
        private BuyInvoiceRepository buyInvoiceRepository;
        private ItemRepository itemRepository;


        public AddBuyInvoice()
        {
            InitializeComponent();
            stockItemRepository = new StockItemRepository();
            buyInvoiceItemRepository = new BuyInvoiceItemRepository();
            itemRepository = new ItemRepository();
            buyInvoiceRepository = new BuyInvoiceRepository();
            dataTable = new BuyInvoiceItemDataTable();
            bindingSource1.DataSource = dataTable;
            BuyInvoiceItemGridView.AutoGenerateColumns = false;
            BuyInvoiceItemGridView.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            dataTable.ColumnChanged += BuyInvoiceItemDataTable_ColumnChanged;

        }
        public void BindItemNumber()
        {
            int i = 1;
            foreach (DataGridViewRow item in BuyInvoiceItemGridView.Rows)
            {
                item.Cells["Number"].Value = i++;
            }
        }
        private void AddBuyInvoice_Load(object sender, EventArgs e)
        {
            BuyInvoiceItemGridView.ShowRowErrors = true;
            PersianCalendar p = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string date = p.GetYear(dt).ToString() + "/" + p.GetMonth(dt).ToString() + "/" + p.GetDayOfMonth(dt).ToString();
            InvoiceDatetxt.Text = date;
            BuyInvoiceErrorProvider.SetError(SRIDTxt, "وارد کردن کد انبار ضروری است");
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            BuyInvoiceItemGridView.CurrentRow.Cells["ItemId"].Value = DBNull.Value;
            BuyInvoiceItemGridView.CurrentRow.Cells["Fee"].Value = DBNull.Value;
            BuyInvoiceItemGridView.CurrentRow.Cells["Quantity"].Value = DBNull.Value;
            BuyInvoiceItemGridView.CurrentRow.Cells["Offer"].Value = 0;
            BuyInvoiceItemGridView.CurrentRow.Cells["Extras"].Value = 0;
            BuyInvoiceItemGridView.CurrentRow.Cells["NetPrice"].Value = 0;
            BuyInvoiceItemGridView.CurrentRow.Cells["TracingFactor"].Value = "";
            BindItemNumber();
        }
        private void BuyInvoiceItemDataTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            
            if (e.Column.ColumnName != "Check")
            {
                if (e.Row[e.Column].Equals(DBNull.Value) && e.Column.ColumnName == "ItemId")
                {
                    e.Row.SetColumnError(e.Column, "شماره کالا نمیتواند خالی باشد");
                    e.Row["ItemTitle"] = "";
                }
                else if (e.Column.ColumnName == "ItemId")
                {
                    DataTable item = itemRepository.FindItem(int.Parse(e.Row[e.Column].ToString()));
                    if (item.Rows.Count != 1)
                    {
                        e.Row.SetColumnError(e.Column, "شماره کالا معتبر نیست");
                        e.Row["ItemTitle"] = "";
                    }
                    else
                    {
                        e.Row.SetColumnError(e.Column, "");
                        e.Row["ItemTitle"] = item.Rows[0]["Title"].ToString();
                    }
                }
                if (e.Row[e.Column].Equals(DBNull.Value) && e.Column.ColumnName == "Fee")
                {
                    e.Row.SetColumnError(e.Column, "فی نمیتواند خالی باشد");
                }
                else if (e.Column.ColumnName == "Fee")
                {
                    e.Row.SetColumnError(e.Column, "");
                }
                else if (e.Row[e.Column].Equals(DBNull.Value) && e.Column.ColumnName == "Quantity")
                {
                    e.Row.SetColumnError(e.Column, "تعداد نمیتواند خالی باشد");
                }
                else if (e.Column.ColumnName == "Quantity")
                {
                    e.Row.SetColumnError(e.Column, "");
                }
                if (!e.Row["Quantity"].Equals(DBNull.Value) && !e.Row["Fee"].Equals(DBNull.Value) && (e.Column.ColumnName == "Fee" || e.Column.ColumnName == "Quantity" || e.Column.ColumnName == "Offer" || e.Column.ColumnName == "Extras"))
                {
                    e.Row["Total"] = (int)e.Row["Fee"] * (int)e.Row["Quantity"];
                    e.Row["NetPrice"] = (int)e.Row["Total"] + (int)e.Row["Extras"] - (int)e.Row["Offer"];
                    ComputingTotals();
                }
            }       
            BuyInvoiceItemGridView.Refresh();
        }
        public void ItemSelected(object sender, SelectEventArgs e)
        {
            BuyInvoiceItemGridView.CurrentRow.Cells["ItemId"].Value = e.ItemId;
            BuyInvoiceItemGridView.CurrentRow.Cells["TracingFactor"].ReadOnly = !e.HasTracingFactor;
        }

        private void SRIDTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                stockRoomForm = new ChooseStockRoomForm(int.Parse(SRIDTxt.Text != "" ? SRIDTxt.Text : "0"));
                //stockRoomForm.MdiParent = this.MdiParent;
                stockRoomForm.ControlBox = false;
                stockRoomForm.FormBorderStyle = FormBorderStyle.None;
                stockRoomForm.Location = SRIDTxt.Location;
                stockRoomForm.Selected += StockRoomSelected;
                stockRoomForm.Show();
            }
        }
        public void StockRoomSelected(object sender, SelectStockRoomEventArgs e)
        {
            SRIDTxt.Text = e.SRId.ToString();
            SRTitleTxt.Text = e.Title;
            BuyInvoiceErrorProvider.SetError(SRIDTxt, "");
        }

        public void ComputingTotals()
        {
            int OfferSum = 0;
            int NetPriceSum = 0;
            int ExtraSum = 0;
            foreach (BuyInvoiceItemDataRow item in dataTable.Rows)
            {
                OfferSum += item.Offer;
                NetPriceSum += item.NetPrice;
                ExtraSum += item.Extras;
            }
            TotalOfferTxt.Text = OfferSum.ToString();
            TotalExtras.Text = ExtraSum.ToString();
            TotalNetPrice.Text = NetPriceSum.ToString();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (dataTable.Rows.Count > 0)
            {
                bool isSuccess = false;
                if (!dataTable.HasErrors && BuyInvoiceErrorProvider.GetError(SRIDTxt) == "" && BuyInvoiceErrorProvider.GetError(InvoiceDatetxt) == "")
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        try
                        {
                            PersianCalendar persianCalendar = new PersianCalendar();
                            string[] persianDate = InvoiceDatetxt.Text.Split('/');
                            DateTime persianDateTime = persianCalendar.ToDateTime(Convert.ToInt32(persianDate[0]), Convert.ToInt32(persianDate[1]), Convert.ToInt32(persianDate[2]), 0, 0, 0, 0);
                            BuyInvoiceModel model = new BuyInvoiceModel();
                            model.SRId = int.Parse(SRIDTxt.Text);
                            model.Supplier = SupplierTxt.Text;
                            model.IsFinally = false;
                            model.CreatedDate = persianDateTime;
                            model.BuyInvoiceId = buyInvoiceRepository.GetLastId() + 1;
                            bool succsess = buyInvoiceRepository.AddItem(model);
                            if (succsess)
                            {
                                foreach (BuyInvoiceItemDataRow item in dataTable.Rows)
                                {
                                    item.BuyInvoiceId = model.BuyInvoiceId;
                                    DataTable table = stockItemRepository.GetStockItem(item.ItemId, model.SRId, item.TracingFactor.ToString());
                                    if (table.Rows.Count == 0)
                                    {
                                        StockItemModel stocModel = new StockItemModel()
                                        {
                                            ItemId = item.ItemId,
                                            SRId = int.Parse(SRIDTxt.Text),
                                            StockValue = 0,
                                            CreatedDate = persianDateTime,
                                            TracingFactor = item.TracingFactor
                                        };
                                        item.StockItemId = stockItemRepository.AddStockItem(stocModel);
                                    }
                                    else if (table.Rows.Count == 1)
                                    {
                                        item.StockItemId = int.Parse(table.Rows[0]["StockItemId"].ToString());
                                    }
                                }
                                if (buyInvoiceItemRepository.UpdateBuyInvoiceItem(dataTable) == true)
                                {
                                    foreach (BuyInvoiceItemDataRow item in dataTable.Rows)
                                    {
                                        stockItemRepository.UpdateStockItem(item.StockItemId, item.Quantity);
                                    }
                                    transaction.Complete();
                                    isSuccess = true;
                                }
                            }
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("عملیات با شکست مواجه شد", "ناموفق");
                            return;
                        }
                    }
                    if (isSuccess)
                    {
                        MessageBox.Show("عملیات با موفقیت انجام شد", "موفق");
                        OnAdded();
                    }
                }
                else
                    MessageBox.Show("لطفا ابتدا خطاهای نمایش داده شده را رفع نمایید", "ناموفق");
            }
            else
                MessageBox.Show(" لطفا ابتدا یک سطر ایجاد کرده و اطلاعات را به درستی وارد نمایید", "ناموفق");
        }
        private void OnAdded()
        {
            if (AddedEvent != null)
                AddedEvent.Invoke(this, new EventArgs());
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            BindItemNumber();
        }

        private void StockBtn_Click(object sender, EventArgs e)
        {
            stockRoomForm = new ChooseStockRoomForm(int.Parse(SRIDTxt.Text != "" ? SRIDTxt.Text : "0"));
            stockRoomForm.MdiParent = this.MdiParent;
            stockRoomForm.ControlBox = false;
            stockRoomForm.FormBorderStyle = FormBorderStyle.None;
            stockRoomForm.Location = SRIDTxt.Location;
            stockRoomForm.Selected += StockRoomSelected;
            stockRoomForm.Show();
        }

        private void BuyInvoiceItemGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                BuyInvoiceItemGridView.EndEdit();
                if (e.ColumnIndex == BuyInvoiceItemGridView.Columns["SelectItemBtn"].Index)
                {
                    itemForm = new ChooseItemForm(BuyInvoiceItemGridView.Rows[e.RowIndex].Cells["ItemId"].Value != DBNull.Value ? (int)BuyInvoiceItemGridView.Rows[e.RowIndex].Cells["ItemId"].Value : 0);
                    itemForm.MdiParent = this.MdiParent;
                    itemForm.ControlBox = false;
                    itemForm.FormBorderStyle = FormBorderStyle.None;
                    itemForm.Location = BuyInvoiceItemGridView.PointToScreen(
                    BuyInvoiceItemGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                    itemForm.Selected += ItemSelected;
                    itemForm.Show();
                }
            }
        }

        private void InvoiceDatetxt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                string[] persianDate = InvoiceDatetxt.Text.Split('/');
                DateTime persianDateTime = persianCalendar.ToDateTime(Convert.ToInt32(persianDate[0]), Convert.ToInt32(persianDate[1]), Convert.ToInt32(persianDate[2]), 0, 0, 0, 0);
                BuyInvoiceErrorProvider.SetError(InvoiceDatetxt, "");
            }
            catch (Exception)
            {
                BuyInvoiceErrorProvider.SetError(InvoiceDatetxt, "تاریخ به درستی وارد نشده است");
            }
        }
        private void CancelBtnTool_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
