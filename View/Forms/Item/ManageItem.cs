using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project.Business;
using Project.Models;
using Project.Models.User;
using Project.Repositories;
using Project.Tools;
using Project.ViewModel;

namespace Project
{
    public partial class ManageItem : Form
    {
        private ItemBusiness itemBusiness;
        public ManageItem()
        {
            InitializeComponent();
            itemBusiness = new ItemBusiness();
        }
        public void BindItemData()
        {
            ItemGridView.AutoGenerateColumns = false;
            ItemGridView.DataSource = null;
            ItemGridView.DataSource = itemBusiness.GetItems();
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
                DeleteCheckedBtn.Visible = false;
            }
            if (!UserModel.HasPermission(Access.EditItem))
                EditBtnTool.Visible = false;
        }
        private void ManageItem_Load(object sender, EventArgs e)
        {
            BindItemData();
            ConfigureAccess();
        }
        private void AddBtnTool_Click(object sender, EventArgs e)
        {
            AddItem a = new AddItem();
            a.AddedEvent += RefreshBtn_Click;
            a.MdiParent = this.MdiParent;
            a.Show();
            a.MdiParent.LayoutMdi(MdiLayout.TileVertical);
        }
        private void EditBtnTool_Click(object sender, EventArgs e)
        {
            if (ItemGridView.CurrentCell != null)
            {
                if (ItemGridView.SelectedCells.Count == 1)
                {
                    ItemViewModel model = new ItemViewModel();
                    DataGridViewRow row = ItemGridView.Rows[ItemGridView.CurrentCell.RowIndex];
                    model.ItemId = int.Parse(row.Cells["ItemId"].Value.ToString());
                    model.Title = row.Cells["Title"].Value.ToString();
                    model.Description = row.Cells["Description"].Value.ToString();
                    model.RefUnitId = int.Parse(row.Cells["RefUnitId"].Value.ToString());
                    if (row.Cells["HasTracingFactor"] != null)
                        model.HasTracingFactor = (bool)row.Cells["HasTracingFactor"].Value;
                    else model.HasTracingFactor = false;
                    if (model.HasTracingFactor) model.TracingFactorId = row.Cells["TracingFactorId"].Value.ToString();
                    else model.TracingFactorId = "0";
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
        private void DeleteCheckedBtn_Click(object sender, EventArgs e)
        {
            ItemGridView.EndEdit();
            try
            {
                List<int> SelectedId = ItemGridView.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Check"].Value != null).Where(r => int.Parse(r.Cells["Check"].Value.ToString()) == 1).Select(r => (int)r.Cells["ItemId"].Value).ToList();
                if (SelectedId.Count == 0)
                    MessageBox.Show("هیچ سطری انتخاب نشده است", "خطا");
                else if (MessageBox.Show("آیا از حذف " + SelectedId.Count + "رکورد مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    if (itemBusiness.RemoveItems(SelectedId))
                    {
                        MessageBox.Show("عملیات با موفقیت انجام شد !", "موفق");
                        BindItemData();
                    }
                }
            }
            catch (Exception) { MessageBox.Show("عملیات با خطا مواجه شد !", "ناموفق"); }
        }
        private void ManageItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            ItemGridView.WriteGrideViewSetting();
        }
        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            BindItemData();
        }
    }
}
