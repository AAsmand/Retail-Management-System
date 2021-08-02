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

namespace Project
{
    public partial class AddItem : Form
    {
        Image Image;
        ItemModel Model;
        bool EditMode = false;
        bool isUpdatedImage = false;
        ItemBusiness itemBus;
        public event EventHandler<AddItemEventArg> AddedEvent;
        private UnitRepository unitRepository;
        private TracingFactorRepository tracingFactorRepository;
        public AddItem()
        {
            InitializeComponent();
            itemBus = new ItemBusiness();
            unitRepository = new UnitRepository();
            tracingFactorRepository = new TracingFactorRepository();
            HasTracingFactor.Checked = true;
        }
        public AddItem(ItemModel model)
        {
            Model = model;
            EditMode = true;
            InitializeComponent();
            itemBus = new ItemBusiness();
            unitRepository = new UnitRepository();
            tracingFactorRepository = new TracingFactorRepository();
            AddBtn.Text = "ویرایش";
            Titletxt.Text = model.Title;
            Descriptiontxt.Text = model.Description;
            PicAddressTxt.Text = model.Pic;
            Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", PicAddressTxt.Text));
            pictureBox1.Image = Image;
            HasTracingFactor.Checked = model.HasTracingFactor;
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
            UnitCombo.DataSource = unitRepository.GetData();
            UnitCombo.DisplayMember = "UnitName";
            UnitCombo.ValueMember = "UnitId";

            TracingCombo.DataSource = tracingFactorRepository.GetData();
            TracingCombo.DisplayMember = "Title";
            TracingCombo.ValueMember = "TracingFactorId";

            if (EditMode)
            {
                UnitCombo.SelectedValue = Model.RefUnitId;
                TracingCombo.SelectedValue = Model.TracingFactorId;
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

            if (AddItemErrorProvider.GetError(Titletxt) == "")
            {
                if (EditMode)
                {
                    if (HasTracingFactor.Checked)
                    {
                        if (itemBus.EditItem(Model.ItemId, Titletxt.Text, Descriptiontxt.Text, (int)UnitCombo.SelectedValue, HasTracingFactor.Checked, (int)TracingCombo.SelectedValue, PicAddressTxt.Text, Model.Pic, Image, isUpdatedImage))
                        {
                            MessageBox.Show("عملیات با موفقیت انجام شد");
                            if (AddedEvent != null)
                                AddedEvent.Invoke(this, new AddItemEventArg() { IsSuccess = true });
                            // this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("عملیات با شکست مواجه شد");
                        }
                    }
                    else
                    {
                        if (itemBus.EditItem(Model.ItemId, Titletxt.Text, Descriptiontxt.Text, (int)UnitCombo.SelectedValue, HasTracingFactor.Checked, 0, PicAddressTxt.Text, Model.Pic, Image, isUpdatedImage))
                        {
                            MessageBox.Show("عملیات با موفقیت انجام شد");
                            if (AddedEvent != null)
                                AddedEvent.Invoke(this, new AddItemEventArg() { IsSuccess = true });
                            // this.DialogResult = DialogResult.OK;
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
                    if (HasTracingFactor.Checked)
                    {
                        if (itemBus.AddItem(Titletxt.Text, Descriptiontxt.Text, (int)UnitCombo.SelectedValue, HasTracingFactor.Checked, (int)TracingCombo.SelectedValue, PicAddressTxt.Text, Image))
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
                    if (itemBus.AddItem(Titletxt.Text, Descriptiontxt.Text, (int)UnitCombo.SelectedValue, HasTracingFactor.Checked, 0, PicAddressTxt.Text, Image))
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
