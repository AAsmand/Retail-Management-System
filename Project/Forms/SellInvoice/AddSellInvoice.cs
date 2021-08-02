using Project.Repositories;
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
using Project.ViewModel;
using Project.Business;

namespace Project
{
    public partial class AddSellInvoice : Form
    {
        public event EventHandler AddedEvent;
        public SellInvoiceItemDataTable dataTable;
        public ChooseItemForm itemForm;
        public ChooseSellType sellTypeForm;
        public ChooseStockItemForm chooseStockItemForm;
        private ChooseItemStockRoom chooseItemStockRoom;
        public ItemRepository itemRepository;
        public SellInvoiceBusiness sellInvoiceBusiness;


        public AddSellInvoice()
        {
            InitializeComponent();
            sellInvoiceBusiness = new SellInvoiceBusiness();
            itemRepository = new ItemRepository();
            dataTable = new SellInvoiceItemDataTable();
            bindingSource1.DataSource = dataTable;
            SellInvoiceItemGridView.AutoGenerateColumns = false;
            SellInvoiceItemGridView.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            dataTable.ColumnChanged += SellInvoiceItemDataTable_ColumnChanged;

        }
        public void BindItemNumber()
        {
            int i = 1;
            foreach (DataGridViewRow item in SellInvoiceItemGridView.Rows)
            {
                item.Cells["Number"].Value = i++;
            }
        }
        private void AddBuyInvoice_Load(object sender, EventArgs e)
        {
            SellInvoiceItemGridView.ShowRowErrors = true;
            PersianCalendar p = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string date = p.GetYear(dt).ToString() + "/" + p.GetMonth(dt).ToString() + "/" + p.GetDayOfMonth(dt).ToString();
            InvoiceDatetxt.Text = date;
            SellInvoiceErrorProvider.SetError(SellTypeIdTxt, "وارد کردن این فیلد ضروری است");
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            SellInvoiceItemGridView.CurrentRow.Cells["ItemId"].Value = DBNull.Value;
            SellInvoiceItemGridView.CurrentRow.Cells["StockRoomId"].Value = DBNull.Value;
            SellInvoiceItemGridView.CurrentRow.Cells["Fee"].Value = DBNull.Value;
            SellInvoiceItemGridView.CurrentRow.Cells["Quantity"].Value = DBNull.Value;
            SellInvoiceItemGridView.CurrentRow.Cells["Offer"].Value = 0;
            SellInvoiceItemGridView.CurrentRow.Cells["Extras"].Value = 0;
            SellInvoiceItemGridView.CurrentRow.Cells["NetPrice"].Value = 0;
            BindItemNumber();
        }
        private void SellInvoiceItemDataTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
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
                else if (e.Row[e.Column].Equals(DBNull.Value) && e.Column.ColumnName == "StockRoomId")
                {
                    e.Row.SetColumnError(e.Column, "شماره انبار نمیتواند خالی باشد");
                    e.Row["TracingFactor"] = "";
                }
                else if (e.Column.ColumnName == "StockRoomId")
                {
                    e.Row.SetColumnError(e.Column, "");
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
                    if ((int)e.Row["HasTracingFactor"] != 0)
                    {
                        if ((int)e.Row[e.Column] > (int)e.Row["StockValue"])
                        {
                            e.Row.SetColumnError(e.Column, "تعداد بیشتر از موجودی است");
                            return;
                        }

                    }

                    e.Row.SetColumnError(e.Column, "");
                }
                if (!e.Row["Quantity"].Equals(DBNull.Value) && !e.Row["Fee"].Equals(DBNull.Value) && (e.Column.ColumnName == "Fee" || e.Column.ColumnName == "Quantity" || e.Column.ColumnName == "Offer" || e.Column.ColumnName == "Extras"))
                {
                    e.Row["Total"] = (int)e.Row["Fee"] * (int)e.Row["Quantity"];
                    e.Row["NetPrice"] = (int)e.Row["Total"] + (int)e.Row["Extras"] - (int)e.Row["Offer"];
                    ComputingTotals();
                }
            }
            SellInvoiceItemGridView.Refresh();
        }
        public void ItemSelected(object sender, SelectEventArgs e)
        {
            SellInvoiceItemGridView.CurrentRow.Cells["ItemId"].Value = e.ItemId;
            SellInvoiceItemGridView.CurrentRow.Cells["HasTracingFactor"].Value = e.HasTracingFactor;
            if (e.HasTracingFactor)
            {
                SellInvoiceItemGridView.CurrentRow.Cells["TracingFactor"].Value = "";
                SellInvoiceItemGridView.CurrentRow.Cells["TracingFactor"].ReadOnly = true;
            }

        }
        public void StockRoomSelected(object sender, SelectStockItemEventArgs e)
        {
            DataGridViewRow row = SellInvoiceItemGridView.Rows.Cast<DataGridViewRow>().SingleOrDefault(r => (int)r.Cells["ItemId"].Value == (int)SellInvoiceItemGridView.CurrentRow.Cells["ItemId"].Value && r.Cells["StockRoomId"].Value != DBNull.Value && int.Parse(r.Cells["StockRoomId"].Value.ToString()) == e.SRId && r.Cells["TracingFactor"].Value.ToString() == e.TracingFactor);
            if (row != null)
            {
                MessageBox.Show("آیتم تکراری است . تغییرات را بر رکورد قبلی اعمال نمایید", "خطا");
                SellInvoiceItemGridView.Rows.Remove(SellInvoiceItemGridView.CurrentRow);
                SellInvoiceItemGridView.CurrentCell = row.Cells["Quantity"];
            }
            else
            {
                SellInvoiceItemGridView.CurrentRow.Cells["StockRoomId"].Value = e.SRId;
                SellInvoiceItemGridView.CurrentRow.Cells["TracingFactor"].Value = e.TracingFactor;
                SellInvoiceItemGridView.CurrentRow.Cells["StockValue"].Value = e.StockValue;
            }

        }
        public void ItemStockRoomSelected(object sender, SelectStockRoomEventArgs e)
        {
            SellInvoiceItemGridView.CurrentRow.Cells["StockRoomId"].Value = e.SRId;
        }

        private void SRIDTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sellTypeForm = new ChooseSellType(int.Parse(SellTypeIdTxt.Text != "" ? SellTypeIdTxt.Text : "0"));
                //stockRoomForm.MdiParent = this.MdiParent;
                sellTypeForm.ControlBox = false;
                sellTypeForm.FormBorderStyle = FormBorderStyle.None;
                sellTypeForm.Location = SellTypeIdTxt.Location;
                sellTypeForm.Selected += SellTypeSelected;
                sellTypeForm.Show();
            }
        }
        public void SellTypeSelected(object sender, SelectSellTypeEventArgs e)
        {

            SellTypeIdTxt.Text = e.SellTypeId.ToString();
            SellTypeTitle.Text = e.SellTypeTitle;
            SellInvoiceErrorProvider.SetError(SellTypeIdTxt, "");
        }

        public void ComputingTotals()
        {
            int OfferSum = 0;
            int NetPriceSum = 0;
            int ExtraSum = 0;
            foreach (SellInvoiceItemDataRow item in dataTable.Rows)
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
                if (!dataTable.HasErrors && SellInvoiceErrorProvider.GetError(SellTypeIdTxt) == "" && SellInvoiceErrorProvider.GetError(InvoiceDatetxt) == "")
                {
                    try
                    {
                        PersianCalendar persianCalendar = new PersianCalendar();
                        string[] persianDate = InvoiceDatetxt.Text.Split('/');
                        DateTime persianDateTime = persianCalendar.ToDateTime(Convert.ToInt32(persianDate[0]), Convert.ToInt32(persianDate[1]), Convert.ToInt32(persianDate[2]), 0, 0, 0, 0);
                        SellInvoiceViewModel model = new SellInvoiceViewModel();
                        model.SellTypeId = int.Parse(SellTypeIdTxt.Text);
                        model.Customer = CustomerTxt.Text;
                        model.CreatedDate = persianDateTime;  
                        model.ItemTable = dataTable;
                        if(sellInvoiceBusiness.AddSellInvoice(model))
                        {
                            MessageBox.Show("عملیات با موفقیت انجام شد", "موفق");
                            OnAdded();
                            return;
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("عملیات با شکست مواجه شد", "ناموفق");
                        return;
                    }
                }
                else
                    MessageBox.Show("لطفا ابتدا خطاهای نمایش داده شده را رفع نمایید", "ناموفق");
            }
            else
                MessageBox.Show("لطفا ابتدا یک سطر ایجاد نمایید", "ناموفق");
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

        }

        private void BuyInvoiceItemGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == senderGrid.Columns["SelectItemBtn"].Index &&
                e.RowIndex >= 0)
            {
                SellInvoiceItemGridView.EndEdit();
                if (e.ColumnIndex == SellInvoiceItemGridView.Columns["SelectItemBtn"].Index)
                {
                    itemForm = new ChooseItemForm(SellInvoiceItemGridView.Rows[e.RowIndex].Cells["ItemId"].Value != DBNull.Value ? (int)SellInvoiceItemGridView.Rows[e.RowIndex].Cells["ItemId"].Value : 0);
                    itemForm.MdiParent = this.MdiParent;
                    itemForm.ControlBox = false;
                    itemForm.FormBorderStyle = FormBorderStyle.None;
                    itemForm.Location = SellInvoiceItemGridView.PointToScreen(
                    SellInvoiceItemGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                    itemForm.Selected += ItemSelected;
                    itemForm.Show();
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == senderGrid.Columns["SelectTracingFactorBtn"].Index &&
                e.RowIndex >= 0)
            {
                if ((int)SellInvoiceItemGridView.Rows[e.RowIndex].Cells["HasTracingFactor"].Value != 0)
                {
                    if (SellInvoiceItemGridView.Rows[e.RowIndex].Cells["ItemTitle"].Value.ToString() != "" && SellInvoiceItemGridView.Rows[e.RowIndex].Cells["StockRoomId"].Value.ToString() != "")
                    {
                        chooseStockItemForm = new ChooseStockItemForm(SellInvoiceItemGridView.Rows[e.RowIndex].Cells["ItemId"].Value != DBNull.Value ? (int)SellInvoiceItemGridView.Rows[e.RowIndex].Cells["ItemId"].Value : 0, SellInvoiceItemGridView.Rows[e.RowIndex].Cells["StockRoomId"].Value != DBNull.Value ? (int)SellInvoiceItemGridView.Rows[e.RowIndex].Cells["StockRoomId"].Value : 0);
                        chooseStockItemForm.MdiParent = this.MdiParent;
                        chooseStockItemForm.ControlBox = false;
                        chooseStockItemForm.FormBorderStyle = FormBorderStyle.None;
                        chooseStockItemForm.Location = SellInvoiceItemGridView.PointToScreen(
                        SellInvoiceItemGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                        chooseStockItemForm.Selected += StockRoomSelected;
                        chooseStockItemForm.Show();
                    }
                    else MessageBox.Show("لطفا ابتدا یک کالا و انبار را انتخاب نمایید", "خطا");
                }
                else
                {
                    MessageBox.Show("این کالا ردیابی ندارد", "خطا");
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == senderGrid.Columns["SelectStockBtn"].Index &&
                e.RowIndex >= 0)
            {
                if (SellInvoiceItemGridView.Rows[e.RowIndex].Cells["ItemTitle"].Value.ToString() != "")
                {
                    chooseItemStockRoom = new ChooseItemStockRoom(SellInvoiceItemGridView.Rows[e.RowIndex].Cells["ItemId"].Value != DBNull.Value ? (int)SellInvoiceItemGridView.Rows[e.RowIndex].Cells["ItemId"].Value : 0, SellInvoiceItemGridView.Rows[e.RowIndex].Cells["StockRoomId"].Value != DBNull.Value ? (int)SellInvoiceItemGridView.Rows[e.RowIndex].Cells["StockRoomId"].Value : 0);
                    chooseItemStockRoom.MdiParent = this.MdiParent;
                    chooseItemStockRoom.ControlBox = false;
                    chooseItemStockRoom.FormBorderStyle = FormBorderStyle.None;
                    chooseItemStockRoom.Location = SellInvoiceItemGridView.PointToScreen(
                    SellInvoiceItemGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                    chooseItemStockRoom.Selected += ItemStockRoomSelected;
                    chooseItemStockRoom.Show();
                }
                else MessageBox.Show("لطفا ابتدا یک کالا را انتخاب نمایید", "خطا");
            }
        }

        private void SellTypeBtn_Click(object sender, EventArgs e)
        {
            sellTypeForm = new ChooseSellType(int.Parse(SellTypeIdTxt.Text != "" ? SellTypeIdTxt.Text : "0"));
            sellTypeForm.MdiParent = this.MdiParent;
            sellTypeForm.ControlBox = false;
            sellTypeForm.FormBorderStyle = FormBorderStyle.None;
            sellTypeForm.Location = SellTypeIdTxt.Location;
            sellTypeForm.Selected += SellTypeSelected;
            sellTypeForm.Show();
        }

        private void InvoiceDatetxt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                string[] persianDate = InvoiceDatetxt.Text.Split('/');
                DateTime persianDateTime = persianCalendar.ToDateTime(Convert.ToInt32(persianDate[0]), Convert.ToInt32(persianDate[1]), Convert.ToInt32(persianDate[2]), 0, 0, 0, 0);
                SellInvoiceErrorProvider.SetError(InvoiceDatetxt, "");
            }
            catch (Exception)
            {
                SellInvoiceErrorProvider.SetError(InvoiceDatetxt, "تاریخ به درستی وارد نشده است");
            }
        }

        private void EditBtnTool_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
