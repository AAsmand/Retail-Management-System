namespace Project
{
    partial class ManageBuyInvoice
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
            this.AddBtnTool = new System.Windows.Forms.ToolStripButton();
            this.DeleteBtnTool = new System.Windows.Forms.ToolStripButton();
            this.EditBtnTool = new System.Windows.Forms.ToolStripButton();
            this.RefreshBtn = new System.Windows.Forms.ToolStripButton();
            this.BuyInvoiceGridView = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BuyInvoiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuyInvoiceGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtnTool,
            this.DeleteBtnTool,
            this.EditBtnTool,
            this.RefreshBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(1069, 91);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddBtnTool
            // 
            this.AddBtnTool.Image = global::Project.Properties.Resources.icons8_plus_64;
            this.AddBtnTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddBtnTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddBtnTool.Name = "AddBtnTool";
            this.AddBtnTool.Size = new System.Drawing.Size(68, 88);
            this.AddBtnTool.Text = "افزودن";
            this.AddBtnTool.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddBtnTool.Click += new System.EventHandler(this.AddBtnTool_Click);
            // 
            // DeleteBtnTool
            // 
            this.DeleteBtnTool.Image = global::Project.Properties.Resources.icons8_delete_64;
            this.DeleteBtnTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteBtnTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteBtnTool.Name = "DeleteBtnTool";
            this.DeleteBtnTool.Size = new System.Drawing.Size(68, 88);
            this.DeleteBtnTool.Text = "حذف";
            this.DeleteBtnTool.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DeleteBtnTool.Click += new System.EventHandler(this.DeleteBtnTool_Click);
            // 
            // EditBtnTool
            // 
            this.EditBtnTool.Image = global::Project.Properties.Resources.icons8_edit_64;
            this.EditBtnTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditBtnTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditBtnTool.Name = "EditBtnTool";
            this.EditBtnTool.Size = new System.Drawing.Size(68, 88);
            this.EditBtnTool.Text = "ویرایش";
            this.EditBtnTool.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Image = global::Project.Properties.Resources.icons8_refresh_love_64;
            this.RefreshBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RefreshBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(68, 88);
            this.RefreshBtn.Text = "بازخوانی";
            this.RefreshBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // BuyInvoiceGridView
            // 
            this.BuyInvoiceGridView.AllowUserToAddRows = false;
            this.BuyInvoiceGridView.AllowUserToDeleteRows = false;
            this.BuyInvoiceGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuyInvoiceGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BuyInvoiceGridView.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.BuyInvoiceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BuyInvoiceGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.BuyInvoiceId,
            this.CreatedDate,
            this.Supplier});
            this.BuyInvoiceGridView.Location = new System.Drawing.Point(0, 93);
            this.BuyInvoiceGridView.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.BuyInvoiceGridView.Name = "BuyInvoiceGridView";
            this.BuyInvoiceGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BuyInvoiceGridView.RowHeadersWidth = 51;
            this.BuyInvoiceGridView.RowTemplate.Height = 24;
            this.BuyInvoiceGridView.Size = new System.Drawing.Size(1069, 313);
            this.BuyInvoiceGridView.TabIndex = 6;
            // 
            // Check
            // 
            this.Check.FalseValue = "0";
            this.Check.HeaderText = "انتخاب";
            this.Check.IndeterminateValue = "0";
            this.Check.MinimumWidth = 6;
            this.Check.Name = "Check";
            this.Check.TrueValue = "1";
            // 
            // BuyInvoiceId
            // 
            this.BuyInvoiceId.DataPropertyName = "BuyInvoiceId";
            this.BuyInvoiceId.HeaderText = "شماره فاکتور";
            this.BuyInvoiceId.MinimumWidth = 6;
            this.BuyInvoiceId.Name = "BuyInvoiceId";
            this.BuyInvoiceId.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "تاریخ";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // Supplier
            // 
            this.Supplier.DataPropertyName = "Supplier";
            this.Supplier.HeaderText = "تامین کننده";
            this.Supplier.MinimumWidth = 6;
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            // 
            // ManageBuyInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1069, 406);
            this.Controls.Add(this.BuyInvoiceGridView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("IRTerafik", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "ManageBuyInvoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "مدیریت فاکتور خرید";
            this.Load += new System.EventHandler(this.ManageBuyInvoice_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuyInvoiceGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddBtnTool;
        private System.Windows.Forms.ToolStripButton DeleteBtnTool;
        private System.Windows.Forms.ToolStripButton EditBtnTool;
        private System.Windows.Forms.ToolStripButton RefreshBtn;
        private System.Windows.Forms.DataGridView BuyInvoiceGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyInvoiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
    }
}