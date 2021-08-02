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
    public partial class ChooseSellType : Form
    {
        private int _sellTypeId;
        public event EventHandler<SelectSellTypeEventArgs> Selected;
        public SellTypeRepository sellTypeRepository;
        public ChooseSellType(int sellTypeId = 0)
        {
            InitializeComponent();
            _sellTypeId = sellTypeId;
            sellTypeRepository = new SellTypeRepository();
        }
        private void ItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnClicked((int)SellTypeGrid.Rows[SellTypeGrid.CurrentCell.RowIndex].Cells["SellTypeId"].Value, SellTypeGrid.Rows[SellTypeGrid.CurrentCell.RowIndex].Cells["SellTypeTitle"].Value.ToString());
        }
        public void OnClicked(int sellTypeId,string sellTypeTitle)
        {
            if (Selected != null)
            {
                Selected.Invoke(this, new SelectSellTypeEventArgs() { SellTypeId = sellTypeId,SellTypeTitle= sellTypeTitle });
                this.Close();
            }
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (SellTypeGrid.CurrentCell != null)
            {
                if (SellTypeGrid.CurrentCell.RowIndex >= 0)
                {
                    OnClicked((int)SellTypeGrid.Rows[SellTypeGrid.CurrentCell.RowIndex].Cells["SellTypeId"].Value, SellTypeGrid.Rows[SellTypeGrid.CurrentCell.RowIndex].Cells["SellTypeTitle"].Value.ToString());
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseSellType_Load(object sender, EventArgs e)
        {
            SellTypeGrid.AutoGenerateColumns = false;
            SellTypeGrid.DataSource = sellTypeRepository.GetData(_sellTypeId);
            SellTypeGrid.CurrentCell = SellTypeGrid.Rows[0].Cells[0];
        }
    }
    public class SelectSellTypeEventArgs : EventArgs
    {
        public int SellTypeId { get; set; }
        public string SellTypeTitle { get; set; }
    }
}
