using Framework;
using Framework.IOC;
using Project.Models.User;
using Project.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utility.Tools
{
    public partial class MainMenu : ToolStrip
    {
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel UserDetalisLabel;
        private ToolStripLabel toolStripLabel2 ;
        public MainMenu()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            foreach (var item in IOC.Container.GetAllInstances<IMadule>())
            {
                ToolStripMenuItem button = new ToolStripMenuItem()
                {
                    Name=item.Name+"Btn",
                    Text = item.Title,
                    Image = Utility.Properties.Resources.icons8_product_documents_48,
                    DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                    TextImageRelation = TextImageRelation.ImageAboveText,
                    ImageScaling = ToolStripItemImageScaling.SizeToFit,
                    Tag = item.GetType(),
                    Font = new Font("B Yekan", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)))
                };
                button.ImageScaling = ToolStripItemImageScaling.None;
                this.Items.Add(button);
                button.Click += Item_Click;
            }
            ConfigureAccess();
            #region MyRegion
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            UserDetalisLabel = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            this.Items.Add(toolStripSeparator1);
            this.toolStripLabel1.Font = new System.Drawing.Font("B Yekan", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(43, 78);
            this.toolStripLabel1.Text = "کاربر";
            // 
            // UserDetalisLabel
            // 
            this.UserDetalisLabel.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.UserDetalisLabel.Name = "UserDetalisLabel";
            this.UserDetalisLabel.Size = new System.Drawing.Size(0, 78);
            this.UserDetalisLabel.Text= UserModel.Name + " " + UserModel.LastName;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("B Yekan", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(132, 78);
            this.toolStripLabel2.Text = "عزیز خوش آمدید !";
            this.Items.AddRange(new ToolStripLabel[] { toolStripLabel1, UserDetalisLabel, toolStripLabel2 });
            #endregion
        }
        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            dynamic frm = IOC.Container.GetInstance((Type)item.Tag);
            frm.MdiParent = (Form)this.Parent;
            frm.Show();
        }
        private void ConfigureAccess()
        {
            if (!UserModel.HasPermission(Access.ManageItem))
                this.Items.Cast<ToolStripMenuItem>().SingleOrDefault(i => i.Name.Contains("ManageItem")).Visible = false;
            if (!UserModel.HasPermission(Access.ManageBuyFactor))
                this.Items.Cast<ToolStripMenuItem>().SingleOrDefault(i => i.Name.Contains("ManageBuyInvoice")).Visible = false;
            if (!UserModel.HasPermission(Access.ManageSellFactor))
                this.Items.Cast<ToolStripMenuItem>().SingleOrDefault(i => i.Name.Contains("ManageSaleInvoice")).Visible = false;
            if (!UserModel.HasPermission(Access.ManageUser))
                this.Items.Cast<ToolStripMenuItem>().SingleOrDefault(i => i.Name.Contains("ManageUser")).Visible = false;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
