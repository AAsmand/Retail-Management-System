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
    public partial class ChooseItemForm : Form
    {
        private int _itemId;
        public event EventHandler<SelectEventArgs> Selected;
        private ItemRepository itemRepository;
        public ChooseItemForm(int itemId = 0)
        {
            InitializeComponent();
            _itemId = itemId;
            itemRepository = new ItemRepository();
        }
        private void ChooseItemForm_Load(object sender, EventArgs e)
        {
            ItemGrid.AutoGenerateColumns = false;
            ItemGrid.DataSource = itemRepository.GetData(_itemId);
            ItemGrid.CurrentCell = ItemGrid.Rows[0].Cells[0];
        }

        private void ItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ItemGrid.CurrentCell.RowIndex >= 0)
            {
                if (ItemGrid.Rows[ItemGrid.CurrentCell.RowIndex].Cells["HasTracingFactor"] != null)
                    OnClicked((int)ItemGrid.Rows[ItemGrid.CurrentCell.RowIndex].Cells["ItemId"].Value, (bool)ItemGrid.Rows[ItemGrid.CurrentCell.RowIndex].Cells["HasTracingFactor"].Value);
                else
                    OnClicked((int)ItemGrid.Rows[ItemGrid.CurrentCell.RowIndex].Cells["ItemId"].Value, false);
            }
        }
        public void OnClicked(int itemId, bool hasTracingFactor)
        {
            if (Selected != null)
            {
                Selected.Invoke(this, new SelectEventArgs() { ItemId = itemId, HasTracingFactor = hasTracingFactor });
                this.Close();
            }
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (ItemGrid.CurrentCell != null)
            {
                if (ItemGrid.CurrentCell.RowIndex >= 0)
                {
                    if (ItemGrid.Rows[ItemGrid.CurrentCell.RowIndex].Cells["HasTracingFactor"] != null)
                        OnClicked((int)ItemGrid.Rows[ItemGrid.CurrentCell.RowIndex].Cells["ItemId"].Value, (bool)ItemGrid.Rows[ItemGrid.CurrentCell.RowIndex].Cells["HasTracingFactor"].Value);
                    else
                        OnClicked((int)ItemGrid.Rows[ItemGrid.CurrentCell.RowIndex].Cells["ItemId"].Value, false);
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    public class SelectEventArgs : EventArgs
    {
        public int ItemId { get; set; }
        public bool HasTracingFactor { get; set; }
    }
}
