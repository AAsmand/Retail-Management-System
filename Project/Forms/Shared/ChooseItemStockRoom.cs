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
    public partial class ChooseItemStockRoom : Form
    {
        private int _itemId;
        private int _stockRoomId;
        public StockItemRepository stockItemRepository;
        public event EventHandler<SelectStockRoomEventArgs> Selected;
        public ChooseItemStockRoom(int itemId ,int stockRoomId=0)
        {
            InitializeComponent();
            _itemId = itemId;
            _stockRoomId = stockRoomId;
            stockItemRepository = new StockItemRepository();
        }
      
        public void OnClicked(int stockRoomId)
        {
            if (Selected != null)
            {
                Selected.Invoke(this, new SelectStockRoomEventArgs() { SRId = stockRoomId});
                this.Close();
            }
        }

        private void StockRoomGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnClicked((int)StockRoomGrid.Rows[e.RowIndex].Cells["SRId"].Value);
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if(StockRoomGrid.CurrentCell!=null)
            {
                if(StockRoomGrid.CurrentCell.RowIndex>=0)
                {
                    OnClicked((int)StockRoomGrid.Rows[StockRoomGrid.CurrentCell.RowIndex].Cells["SRId"].Value);
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
            StockRoomGrid.DataSource = stockItemRepository.GetStockRoomsForItem(_itemId, _stockRoomId);
        }
    }

}
