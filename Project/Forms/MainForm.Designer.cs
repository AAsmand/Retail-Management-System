namespace Project
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ProductButton = new System.Windows.Forms.ToolStripButton();
            this.UnitButton = new System.Windows.Forms.ToolStripButton();
            this.FactorButton = new System.Windows.Forms.ToolStripButton();
            this.ManageSellInvoiceBtn = new System.Windows.Forms.ToolStripButton();
            this.ManageUsersBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.UserDetalisLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProductButton,
            this.UnitButton,
            this.FactorButton,
            this.ManageSellInvoiceBtn,
            this.ManageUsersBtn,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.UserDetalisLabel,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(1022, 81);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ProductButton
            // 
            this.ProductButton.Font = new System.Drawing.Font("B Yekan", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ProductButton.Image = global::Utility.Properties.Resources.icons8_product_documents_48;
            this.ProductButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ProductButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProductButton.Name = "ProductButton";
            this.ProductButton.Size = new System.Drawing.Size(91, 78);
            this.ProductButton.Text = "مدیریت کالا";
            this.ProductButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ProductButton.Click += new System.EventHandler(this.ProductButton_Click);
            // 
            // UnitButton
            // 
            this.UnitButton.Font = new System.Drawing.Font("B Yekan", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UnitButton.Image = global::Utility.Properties.Resources.icons8_product_documents_48;
            this.UnitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.UnitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UnitButton.Name = "UnitButton";
            this.UnitButton.Size = new System.Drawing.Size(102, 78);
            this.UnitButton.Text = "مدیریت واحد";
            this.UnitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // FactorButton
            // 
            this.FactorButton.Font = new System.Drawing.Font("B Yekan", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FactorButton.Image = global::Utility.Properties.Resources.icons8_product_documents_48;
            this.FactorButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FactorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FactorButton.Name = "FactorButton";
            this.FactorButton.Size = new System.Drawing.Size(147, 78);
            this.FactorButton.Text = "مدیریت فاکتور خرید";
            this.FactorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.FactorButton.Click += new System.EventHandler(this.FactorButton_Click);
            // 
            // ManageSellInvoiceBtn
            // 
            this.ManageSellInvoiceBtn.Font = new System.Drawing.Font("B Yekan", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ManageSellInvoiceBtn.Image = global::Utility.Properties.Resources.icons8_product_documents_48;
            this.ManageSellInvoiceBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManageSellInvoiceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageSellInvoiceBtn.Name = "ManageSellInvoiceBtn";
            this.ManageSellInvoiceBtn.Size = new System.Drawing.Size(156, 78);
            this.ManageSellInvoiceBtn.Text = "مدیریت فاکتور فروش";
            this.ManageSellInvoiceBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ManageSellInvoiceBtn.Click += new System.EventHandler(this.ManageSellInvoiceBtn_Click);
            // 
            // ManageUsersBtn
            // 
            this.ManageUsersBtn.Font = new System.Drawing.Font("B Yekan", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ManageUsersBtn.Image = global::Utility.Properties.Resources.icons8_product_documents_48;
            this.ManageUsersBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManageUsersBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageUsersBtn.Name = "ManageUsersBtn";
            this.ManageUsersBtn.Size = new System.Drawing.Size(190, 78);
            this.ManageUsersBtn.Text = "مدیریت کاربران و دسترسی";
            this.ManageUsersBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ManageUsersBtn.Click += new System.EventHandler(this.ManageUsersBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 81);
            // 
            // toolStripLabel1
            // 
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
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("B Yekan", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(132, 78);
            this.toolStripLabel2.Text = "عزیز خوش آمدید !";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1022, 416);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("B Traffic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "صفحه اصلی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ProductButton;
        private System.Windows.Forms.ToolStripButton UnitButton;
        private System.Windows.Forms.ToolStripButton FactorButton;
        private System.Windows.Forms.ToolStripButton ManageSellInvoiceBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel UserDetalisLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton ManageUsersBtn;
    }
}

