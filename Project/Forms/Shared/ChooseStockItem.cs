using Project.Repositories;
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
    public partial class ChooseStockItemForm : Form
    {
        private int _itemId;
        private int _stockRoomId;
        public StockItemRepository stockItemRepository;
        public event EventHandler<SelectStockItemEventArgs> Selected;
        public ChooseStockItemForm(int itemId ,int stockRoomId=0)
        {
            InitializeComponent();
            _itemId = itemId;
            _stockRoomId = stockRoomId;
            stockItemRepository = new StockItemRepository();
        }
      
        public void OnClicked(int stockRoomId,string tracingFactor,int stockvalue)
        {
            if (Selected != null)
            {
                Selected.Invoke(this, new SelectStockItemEventArgs() { SRId = stockRoomId, TracingFactor= tracingFactor ,StockValue=stockvalue});
                this.Close();
            }
        }

        private void StockRoomGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnClicked((int)StockRoomGrid.Rows[e.RowIndex].Cells["SRId"].Value, StockRoomGrid.Rows[e.RowIndex].Cells["TracingFactor"].Value.ToString(), (int)StockRoomGrid.Rows[e.RowIndex].Cells["StockValue"].Value);
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if(StockRoomGrid.CurrentCell!=null)
            {
                if(StockRoomGrid.CurrentCell.RowIndex>=0)
                {
                    OnClicked((int)StockRoomGrid.Rows[StockRoomGrid.CurrentCell.RowIndex].Cells["SRId"].Value, StockRoomGrid.Rows[StockRoomGrid.CurrentCell.RowIndex].Cells["TracingFactor"].Value.ToString(), (int)StockRoomGrid.Rows[StockRoomGrid.CurrentCell.RowIndex].Cells["StockValue"].Value);
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseStockItemForm_Load(object sender, EventArgs e)
        {
            StockRoomGrid.AutoGenerateColumns = false;
            StockRoomGrid.DataSource = stockItemRepository.GetStockItems(_itemId, _stockRoomId);
        }
    }


    public class SelectStockItemEventArgs : EventArgs
    {
        public int SRId { get; set; }
        public string TracingFactor { get; set; }
        public int StockValue { get; set; }
    }
}
