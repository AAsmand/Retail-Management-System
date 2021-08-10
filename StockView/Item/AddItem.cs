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
using Project.Repositories;
using Project.ViewModel;

namespace Project
{
    public partial class AddItem : Form
    {
        Image Image;
        ItemViewModel Model;
        bool EditMode = false;
        bool isUpdatedImage = false;
        private IItemBusiness itemBus;
        public event EventHandler<AddItemEventArg> AddedEvent;
        private IUnitBusiness unitBusiness;
        private ITracingFactorBusiness tracingFactorBusiness;
        public AddItem(IUnitBusiness unitBusiness, ITracingFactorBusiness tracingFactorBusiness, IItemBusiness itemBus)
        {
            InitializeComponent();
            this.itemBus = itemBus;
            this.unitBusiness = unitBusiness;
            this.tracingFactorBusiness = tracingFactorBusiness;
            HasTracingFactor.Checked = true;
        }
        public AddItem(bool editMode, ItemViewModel model, IUnitBusiness unitBusiness, ITracingFactorBusiness tracingFactorBusiness, IItemBusiness itemBus)
        {
            InitializeComponent();
            this.itemBus = itemBus;
            this.unitBusiness = unitBusiness;
            this.tracingFactorBusiness = tracingFactorBusiness;
            if (editMode)
            {
                Model = model;
                EditMode = true;
                AddBtn.Text = "ویرایش";
                Titletxt.Text = model.Title;
                Descriptiontxt.Text = model.Description;
                PicAddressTxt.Text = model.Pic;
                if (model != null) Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", PicAddressTxt.Text));
                pictureBox1.Image = Image;
                HasTracingFactor.Checked = model.HasTracingFactor;
            }
        }

        private void SelectPic_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG (*.JPG)|*.jpg|PNG (*.PNG)|*.png";
            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                PicAddressTxt.Text = openFileDialog1.SafeFileName;
                Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = Image;
                isUpdatedImage = true;
            }
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            UnitCombo.DataSource = unitBusiness.GetUnits();
            UnitCombo.DisplayMember = "UnitName";
            UnitCombo.ValueMember = "UnitId";

            TracingCombo.DataSource = tracingFactorBusiness.GetTracingFactors();
            TracingCombo.DisplayMember = "Title";
            TracingCombo.ValueMember = "TracingFactorId";

            if (EditMode)
            {
                UnitCombo.SelectedValue = Model.RefUnitId;
                if (Model.HasTracingFactor)
                    TracingCombo.SelectedValue = int.Parse(Model.TracingFactorId);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (AddItemErrorProvider.GetError(Titletxt) == "")
            {
                if (EditMode)
                {

                    if (itemBus.EditItem(Model.ItemId, Titletxt.Text, Descriptiontxt.Text, (int)UnitCombo.SelectedValue, HasTracingFactor.Checked, HasTracingFactor.Checked ? TracingCombo.SelectedValue.ToString() : "0", PicAddressTxt.Text, Model.Pic, Image, isUpdatedImage))
                    {
                        MessageBox.Show("عملیات با موفقیت انجام شد");
                        if (AddedEvent != null)
                            AddedEvent.Invoke(this, new AddItemEventArg() { IsSuccess = true });
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("عملیات با شکست مواجه شد");
                    }

                }
                else
                {
                    if (itemBus.AddItem(Titletxt.Text, Descriptiontxt.Text, (int)UnitCombo.SelectedValue, HasTracingFactor.Checked, HasTracingFactor.Checked ? TracingCombo.SelectedValue.ToString() : "0", PicAddressTxt.Text, Image))
                    {
                        MessageBox.Show("عملیات با موفقیت انجام شد");
                        AddedEvent.Invoke(this, new AddItemEventArg() { IsSuccess = true });
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("عملیات با شکست مواجه شد");
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفا ابتدا خطاهای نمایش داده شده را برطرف نمایید", "خطا");
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Titletxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Titletxt.Text))
            {
                AddItemErrorProvider.SetError(Titletxt, "وارد کردن فیلد عنوان ضروری است");
            }
            else
            {
                AddItemErrorProvider.SetError(Titletxt, "");
            }
        }

        private void HasTracingFactor_CheckedChanged(object sender, EventArgs e)
        {
            TracingCombo.Enabled = HasTracingFactor.Checked;
        }
    }
    public class AddItemEventArg : EventArgs
    {
        public bool IsSuccess { get; set; }
    }
}
