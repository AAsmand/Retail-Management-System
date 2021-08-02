using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project.Models;
using Project.Models.User;
using Project.Repositories;
using Project.Tools;

namespace Project
{
    public partial class ManageItem : Form
    {
        private ItemRepository itemRepository;
        public ManageItem()
        {
            InitializeComponent();
            itemRepository = new ItemRepository();
        }
        public void BindItemData()
        {
            ItemGridView.AutoGenerateColumns = false;
            ItemGridView.DataSource = null;
            ItemGridView.DataSource = itemRepository.GetData();
            Bitmap bmpImage = null;
            for (int i = 0; i < ItemGridView.Rows.Count ; i++)
            {
                bmpImage = (Bitmap)Image.FromFile(Path.Combine(Application.StartupPath, "Images", ItemGridView.Rows[i].Cells["picAddress"].Value.ToString()), true);
                ItemGridView.Rows[i].Cells["pic"].Value = bmpImage;
                ItemGridView.Rows[i].Height = 100;
            }
        }
        private void ConfigureAccess()
        {
            if (!UserModel.HasPermission(Access.AddItem))
                AddBtnTool.Visible = false;
            if (!UserModel.HasPermission(Access.DeleteItem))
            {
                DeleteBtnTool.Visible = false;
                BulkDeleteBtn.Visible = false;
                DeleteCheckedBtn.Visible = false;
            }
            if (!UserModel.HasPermission(Access.EditItem))
                EditBtnTool.Visible = false;
        }
        private void ManageItem_Load(object sender, EventArgs e)
        {
            BindItemData();
           // List<string> list=DGVSetting.ReadDataGridViewSetting(ItemGridView, "ItemGridView");
           // FillHideMenu(list);
            ConfigureAccess();
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (ItemGridView.CurrentCell != null)
            {
                int ItemId = int.Parse(ItemGridView.Rows[ItemGridView.CurrentCell.RowIndex].Cells["ItemId"].Value.ToString());
                if (MessageBox.Show("آیا از حذف آیتم شماره " + ItemId + "مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    itemRepository.DeleteItem(ItemId);
                    BindItemData();
                }
            }
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            AddItem a = new AddItem();
            a.Show();
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            ItemModel model = new ItemModel();
            DataGridViewRow row = ItemGridView.Rows[ItemGridView.CurrentCell.RowIndex];
            model.ItemId = int.Parse(row.Cells["ItemId"].Value.ToString());
            model.Title = row.Cells["Title"].Value.ToString();
            model.Description = row.Cells["Description"].Value.ToString();
            model.RefUnitId = int.Parse(row.Cells["UnitId"].Value.ToString());
            model.TracingFactorId = int.Parse(row.Cells["TracingFactorId"].Value.ToString());
            model.Pic = row.Cells["picAddress"].Value.ToString();
            AddItem a = new AddItem(model);
            a.Show();
        }

        private void AddBtnTool_Click(object sender, EventArgs e)
        {
            AddItem a = new AddItem();
            //((Button)a.Controls.Find("AddBtn", true).FirstOrDefault()).Click += RefreshBtn_Click;
            a.AddedEvent += RefreshBtn_Click;
            a.MdiParent = this.MdiParent;
            a.Show();
            a.MdiParent.LayoutMdi(MdiLayout.TileVertical);
        }
        
        private void DeleteBtnTool_Click(object sender, EventArgs e)
        {
            if (ItemGridView.CurrentCell != null)
            {
                if (ItemGridView.SelectedCells.Count == 1)
                {
                    int ItemId = int.Parse(ItemGridView.Rows[ItemGridView.CurrentCell.RowIndex].Cells["ItemId"].Value.ToString());
                    if (MessageBox.Show("آیا از حذف آیتم شماره " + ItemId + "مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        itemRepository.DeleteItem(ItemId);
                        BindItemData();
                    }
                }
                else
                {
                    MessageBox.Show(" بیش از یک خانه انتخاب شده است ! لطفا یک خانه را انتخاب نمایید و مجددا تلاش کنید ", "خطا");
                }
            }
            else
            {
                MessageBox.Show("هیچ خانه ای انتخاب نشده ! لطفا یک خانه را انتخاب نمایید و مجددا تلاش کنید ", "خطا");
            }
        }

        private void EditBtnTool_Click(object sender, EventArgs e)
        {
            if (ItemGridView.CurrentCell != null)
            {
                if (ItemGridView.SelectedCells.Count == 1)
                {
                    ItemModel model = new ItemModel();
                    DataGridViewRow row = ItemGridView.Rows[ItemGridView.CurrentCell.RowIndex];
                    model.ItemId = int.Parse(row.Cells["ItemId"].Value.ToString());
                    model.Title = row.Cells["Title"].Value.ToString();
                    model.Description = row.Cells["Description"].Value.ToString();
                    model.RefUnitId = int.Parse(row.Cells["UnitId"].Value.ToString());
                    if (row.Cells["HasTracingFactor"] != null)
                        model.HasTracingFactor = (bool)row.Cells["HasTracingFactor"].Value;
                    else model.HasTracingFactor = false;
                    if (model.HasTracingFactor) model.TracingFactorId = int.Parse(row.Cells["TracingFactorId"].Value.ToString());
                    else model.TracingFactorId = 0;
                    model.Pic = row.Cells["picAddress"].Value.ToString();
                    AddItem a = new AddItem(model);
                    //((Button)a.Controls.Find("AddBtn", true).FirstOrDefault()).Click += RefreshBtn_Click;
                    a.AddedEvent += RefreshBtn_Click;
                    a.MdiParent = this.MdiParent;
                    row.Cells["pic"].Value = null;
                    a.Show();
                }
                else
                {
                    MessageBox.Show(" بیش از یک خانه انتخاب شده است ! لطفا یک خانه را انتخاب نمایید و مجددا تلاش کنید ", "خطا");
                }
            }
            else
            {
                MessageBox.Show("هیچ خانه ای انتخاب نشده ! لطفا یک خانه را انتخاب نمایید و مجددا تلاش کنید ", "خطا");
            }
        }

        //private void ItemGridView_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && (e.KeyCode == Keys.N))
        //    {
        //        string column = ItemGridView.Columns[ItemGridView.CurrentCell.ColumnIndex].Name;
        //        ItemGridView.Columns[column].Visible = false;
        //        (Gridmenu.Items["HideColumn"] as ToolStripMenuItem).DropDownItems.Add(column);
        //    }
        //}
        //private void FillHideMenu(List<string> deactiveList)
        //{
        //    (Gridmenu.Items["HideColumn"] as ToolStripMenuItem).DropDownItems.Clear();
        //    foreach (string item in deactiveList)
        //    {
        //        (Gridmenu.Items["HideColumn"] as ToolStripMenuItem).DropDownItems.Add(ItemGridView.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c=>c.Name==item).HeaderText);
        //    }
        //}
       
        //private void HideColumn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    var menuText =ItemGridView.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c=>c.HeaderText== e.ClickedItem.Text).Name ;
        //    ItemGridView.Columns[menuText].Visible = true;
        //    (Gridmenu.Items["HideColumn"] as ToolStripMenuItem).DropDownItems.Remove(e.ClickedItem);
        //}

        private void BulkDeleteBtn_Click(object sender, EventArgs e)
        {
            if (ItemGridView.SelectedRows.Count == 0)
                MessageBox.Show("هیچ سطری انتخاب نشده است", "خطا");
            else if (MessageBox.Show("آیا از حذف " + ItemGridView.SelectedRows.Count + "رکورد مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                
                foreach (var item in ItemGridView.SelectedRows)
                {
                    DataGridViewRow d = (DataGridViewRow)item;
                    itemRepository.DeleteItem((int)d.Cells["ItemId"].Value);
                }
                MessageBox.Show("عملیات با موفقیت انجام شد !", "موفق");
            }
        }

        private void DeleteCheckedBtn_Click(object sender, EventArgs e)
        {
            ItemGridView.EndEdit();
            try
            {
                List<int> list2 = ItemGridView.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Check"].Value != null).Where(r => int.Parse(r.Cells["Check"].Value.ToString()) == 1).Select(r => (int)r.Cells["ItemId"].Value).ToList();
                if (list2.Count == 0)
                    MessageBox.Show("هیچ سطری انتخاب نشده است", "خطا");
                else if (MessageBox.Show("آیا از حذف " + list2.Count + "رکورد مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    List<int> list = new List<int>();
                    foreach (DataGridViewRow row in ItemGridView.Rows)
                    {
                        if (row.Cells["Check"].Value != null)
                        {
                            if (int.Parse(row.Cells["Check"].Value.ToString()) == 1)
                            {
                                itemRepository.DeleteItem((int)row.Cells["ItemId"].Value);
                            }
                        }
                    }
                    MessageBox.Show("عملیات با موفقیت انجام شد !", "موفق");
                }
            }
            catch (Exception) { }
        }

        private void ManageItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DGVSetting.WriteGrideViewSetting(ItemGridView, "ItemGridView");
            ItemGridView.WriteGrideViewSetting();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            BindItemData();
        }
    }
}
