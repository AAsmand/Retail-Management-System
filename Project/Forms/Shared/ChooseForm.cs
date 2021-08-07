using Project.Business;
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
using Utility.Interfaces;

namespace Project.Forms.Shared
{
    public partial class ChooseForm : Form
    {
        public event EventHandler<SelectEventArgs> Selected;
        IBaseUiView uiView;
        public ChooseForm(IBaseUiView view)
        {
            uiView = view;
            InitializeComponent();

        }
        private void ChooseItemForm_Load(object sender, EventArgs e)
        {
            ChooseGridView.AutoGenerateColumns = false;
            ChooseGridView.DataSource = uiView.GetData();
            ChooseGridView.Columns.AddRange(uiView.GetColumn().ToArray());
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
