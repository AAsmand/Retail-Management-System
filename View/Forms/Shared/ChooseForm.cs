using Project.Business;
using Project.Business.ChooseBusiness;
using Project.Repositories;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project.Forms.Shared
{
    public partial class ChooseForm<TBusiness> : Form where TBusiness : IChooseBusiness, new()
    {
        public event EventHandler<SelectEventArgs> Selected;
        TBusiness business;
        object[] _parameters;
        public ChooseForm(params object[] parameters)
        {
            _parameters = parameters;
            business = new TBusiness();
            InitializeComponent();

        }
        private void ChooseItemForm_Load(object sender, EventArgs e)
        {
            if (typeof(TBusiness) == typeof(ItemBusiness))
            {
                ChooseGridView.Columns.AddRange(
                    new DataGridViewTextBoxColumn() { Name = "ItemId", HeaderText = "شماره کالا/خدمت", DataPropertyName = "ItemId" },
                    new DataGridViewTextBoxColumn() { Name = "Title", HeaderText = "عنوان", DataPropertyName = "Title" },
                    new DataGridViewCheckBoxColumn() { Name = "HasTracingFactor", HeaderText = "ردیابی", DataPropertyName = "HasTracingFactor" }
                    );
            }
            if (typeof(TBusiness) == typeof(StockRoomBusiness))
            {
                ChooseGridView.Columns.AddRange(
                    new DataGridViewTextBoxColumn() { Name = "SRId", HeaderText = "شماره انبار", DataPropertyName = "SRId" },
                    new DataGridViewTextBoxColumn() { Name = "Title", HeaderText = "عنوان", DataPropertyName = "Title" },
                    new DataGridViewTextBoxColumn() { Name = "Address", HeaderText = "آدرس", DataPropertyName = "Address" }
                    );
            }
            if (typeof(TBusiness) == typeof(StockItemBusiness))
            {
                ChooseGridView.Columns.AddRange(
                    new DataGridViewTextBoxColumn() { Name = "StockItemId", HeaderText = "شماره یکتا", DataPropertyName = "StockItemId" },
                    new DataGridViewTextBoxColumn() { Name = "SRId", HeaderText = "شماره انبار", DataPropertyName = "SRId" },
                    new DataGridViewTextBoxColumn() { Name = "Title", HeaderText = "عنوان", DataPropertyName = "Title" },
                    new DataGridViewTextBoxColumn() { Name = "StockValue", HeaderText = "موجودی", DataPropertyName = "StockValue" },
                    new DataGridViewTextBoxColumn() { Name = "TracingFactor", HeaderText = "عامل ردیابی", DataPropertyName = "TracingFactor" }
                    );
            }
            if (typeof(TBusiness) == typeof(SellTypeBusiness))
            {
                ChooseGridView.Columns.AddRange(
                    new DataGridViewTextBoxColumn() { Name = "SellTypeId", HeaderText = "شماره نوع فروش", DataPropertyName = "SellTypeId" },
                    new DataGridViewTextBoxColumn() { Name = "SellTypeTitle", HeaderText = "عنوان", DataPropertyName = "SellTypeTitle" }
                    );
            }
            if (typeof(TBusiness) == typeof(RoleBusiness))
            {
                ChooseGridView.Columns.AddRange(
                    new DataGridViewTextBoxColumn() { Name = "RoleId", HeaderText = "شماره نقش", DataPropertyName = "RoleId" },
                    new DataGridViewTextBoxColumn() { Name = "RoleName", HeaderText = "عنوان", DataPropertyName = "RoleName" }
                    );
            }
            ChooseGridView.AutoGenerateColumns = false;
            ChooseGridView.DataSource = business.GetDataForChoose(_parameters);
        }

        public void OnClicked(int id)
        {
            if (Selected != null)
            {
                Selected.Invoke(this, new SelectEventArgs() { Id = id });
            }
            this.Close();
        }
        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (ChooseGridView.CurrentCell != null)
            {
                if (ChooseGridView.CurrentCell.RowIndex >= 0)
                {
                    OnClicked((int)ChooseGridView.Rows[ChooseGridView.CurrentCell.RowIndex].Cells[0].Value);
                }
            }
        }
        private void ChooseGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ChooseGridView.CurrentCell.RowIndex >= 0)
            {
                OnClicked((int)ChooseGridView.Rows[ChooseGridView.CurrentCell.RowIndex].Cells[0].Value);
            }
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    #region EventArgs Classes
    public class SelectItemEventArgs : EventArgs
    {
        public int ItemId { get; set; }
        public bool HasTracingFactor { get; set; }
    }
    public class SelectStockRoomEventArgs : EventArgs
    {
        public int SRId { get; set; }
        public string Title { get; set; }
    }
    public class SelectEventArgs : EventArgs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Check { get; set; }
    }
    #endregion


}
