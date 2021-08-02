using Project.Models.Role;
using Project.Repositories;
using Project.Repositories.Role;
using Project.ViewModel;
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
    public partial class ChooseRoll : Form
    {
        private string _roleId;
        public event EventHandler<SelectRoleEventArgs> Selected;
        public RoleRepository rollRepository;
        private List<RoleViewModel> _currentRoles;
        public ChooseRoll(string roleId, List<RoleViewModel> currentRoles)
        {
            InitializeComponent();
            _roleId = roleId;
            rollRepository = new RoleRepository();
            _currentRoles = currentRoles;
        }
        private void ItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnClicked((int)RoleGrid.Rows[RoleGrid.CurrentCell.RowIndex].Cells["SellTypeId"].Value, RoleGrid.Rows[RoleGrid.CurrentCell.RowIndex].Cells["SellTypeTitle"].Value.ToString());
        }
        public void OnClicked(int rollId,string rollName)
        {
            if (Selected != null)
            {
                Selected.Invoke(this, new SelectRoleEventArgs() { RoleId = rollId, RoleName= rollName });
                this.Close();
            }
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (RoleGrid.CurrentCell != null)
            {
                if (RoleGrid.CurrentCell.RowIndex >= 0)
                {
                    OnClicked(int.Parse(RoleGrid.Rows[RoleGrid.CurrentCell.RowIndex].Cells["RoleId"].Value.ToString()), RoleGrid.Rows[RoleGrid.CurrentCell.RowIndex].Cells["RoleName"].Value.ToString());
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseSellType_Load(object sender, EventArgs e)
        {
            RoleGrid.AutoGenerateColumns = false;
            List<RoleViewModel> l= rollRepository.GetRoles(_roleId).Rows.Cast<DataRow>().Where(r=>!_currentRoles.Any(cr=>cr.RoleId==r["RoleId"].ToString())).Select(r => new RoleViewModel() { RoleId = r["RoleId"].ToString(), RoleName = r["RoleName"].ToString() }).ToList();
            RoleGrid.DataSource = l;
        }
    }
    public class SelectRoleEventArgs : EventArgs
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
