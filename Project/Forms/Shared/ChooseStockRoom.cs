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
    public partial class ChooseStockRoomForm : Form
    {
        private int _itemId;
        public event EventHandler<SelectStockRoomEventArgs> Selected;
        private StockRoomRepository stockRoomRepository;
        public ChooseStockRoomForm(int itemId = 0)
        {
            InitializeComponent();
            _itemId = itemId;
            stockRoomRepository = new StockRoomRepository();
        }
        private void ChooseItemForm_Load(object sender, EventArgs e)
        {
            StockRoomGrid.AutoGenerateColumns = false;
            StockRoomGrid.DataSource = stockRoomRepository.GetData(_itemId);
            StockRoomGrid.CurrentCell = StockRoomGrid.Rows[0].Cells[0];
        }

        public void OnClicked(int itemId,string srTitle)
        {
            if (Selected != null)
            {
                Selected.Invoke(this, new SelectStockRoomEventArgs() { SRId = itemId ,Title=srTitle});
                this.Close();
            }
        }

        private void StockRoomGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnClicked((int)StockRoomGrid.Rows[e.RowIndex].Cells["SRId"].Value, StockRoomGrid.Rows[e.RowIndex].Cells["Title"].Value.ToString());
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if(StockRoomGrid.CurrentCell!=null)
            {
                if(StockRoomGrid.CurrentCell.RowIndex>=0)
                {
                    OnClicked((int)StockRoomGrid.Rows[StockRoomGrid.CurrentCell.RowIndex].Cells["SRId"].Value, StockRoomGrid.Rows[StockRoomGrid.CurrentCell.RowIndex].Cells["Title"].Value.ToString());
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    public class SelectStockRoomEventArgs : EventArgs
    {
        public int SRId { get; set; }
        public string Title { get; set; }
    }
}
