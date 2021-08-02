namespace Project
{
    partial class ManageItem
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddBtnTool = new System.Windows.Forms.ToolStripButton();
            this.DeleteBtnTool = new System.Windows.Forms.ToolStripButton();
            this.EditBtnTool = new System.Windows.Forms.ToolStripButton();
            this.BulkDeleteBtn = new System.Windows.Forms.ToolStripButton();
            this.DeleteCheckedBtn = new System.Windows.Forms.ToolStripButton();
            this.RefreshBtn = new System.Windows.Forms.ToolStripButton();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pic = new System.Windows.Forms.DataGridViewImageColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasTracingFactor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TracingFactor_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TracingFactorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGridView = new CustomGridView("ItemGridView");
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtnTool,
            this.DeleteBtnTool,
            this.EditBtnTool,
            this.BulkDeleteBtn,
            this.DeleteCheckedBtn,
            this.RefreshBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(811, 91);
            this.toolStrip1.TabIndex = 4;
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
            this.EditBtnTool.Click += new System.EventHandler(this.EditBtnTool_Click);
            // 
            // BulkDeleteBtn
            // 
            this.BulkDeleteBtn.Image = global::Project.Properties.Resources.icons8_delete_64;
            this.BulkDeleteBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BulkDeleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BulkDeleteBtn.Name = "BulkDeleteBtn";
            this.BulkDeleteBtn.Size = new System.Drawing.Size(154, 88);
            this.BulkDeleteBtn.Text = "حذف سطرهای انتخابی";
            this.BulkDeleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BulkDeleteBtn.Click += new System.EventHandler(this.BulkDeleteBtn_Click);
            // 
            // DeleteCheckedBtn
            // 
            this.DeleteCheckedBtn.Image = global::Project.Properties.Resources.icons8_delete_64;
            this.DeleteCheckedBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteCheckedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteCheckedBtn.Name = "DeleteCheckedBtn";
            this.DeleteCheckedBtn.Size = new System.Drawing.Size(175, 88);
            this.DeleteCheckedBtn.Text = "حذف سطرهای تیک خورده";
            this.DeleteCheckedBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DeleteCheckedBtn.Click += new System.EventHandler(this.DeleteCheckedBtn_Click);
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
            // ItemGridView
            // 
            this.ItemGridView.AllowUserToAddRows = false;
            this.ItemGridView.AllowUserToDeleteRows = false;
            this.ItemGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ItemGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.ItemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.ItemId,
            this.pic,
            this.Title,
            this.Description,
            this.UnitName,
            this.HasTracingFactor,
            this.TracingFactor_Title,
            this.picAddress,
            this.TracingFactorId,
            this.UnitId});
            this.ItemGridView.Location = new System.Drawing.Point(0, 96);
            this.ItemGridView.Name = "ItemGridView";
            this.ItemGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ItemGridView.RowHeadersWidth = 51;
            this.ItemGridView.Size = new System.Drawing.Size(811, 358);
            this.ItemGridView.TabIndex = 5;
            
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
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.HeaderText = "شماره کالا/خدمت";
            this.ItemId.MinimumWidth = 6;
            this.ItemId.Name = "ItemId";
            // 
            // pic
            // 
            this.pic.HeaderText = "تصویر";
            this.pic.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.pic.MinimumWidth = 6;
            this.pic.Name = "pic";
            this.pic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "نام";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "توضیحات";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitName";
            this.UnitName.HeaderText = "واحد اصلی";
            this.UnitName.MinimumWidth = 6;
            this.UnitName.Name = "UnitName";
            // 
            // HasTracingFactor
            // 
            this.HasTracingFactor.DataPropertyName = "HasTracingFactor";
            this.HasTracingFactor.FalseValue = "F";
            this.HasTracingFactor.HeaderText = "ردیابی";
            this.HasTracingFactor.MinimumWidth = 6;
            this.HasTracingFactor.Name = "HasTracingFactor";
            this.HasTracingFactor.ReadOnly = true;
            this.HasTracingFactor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HasTracingFactor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.HasTracingFactor.TrueValue = "T";
            // 
            // TracingFactor_Title
            // 
            this.TracingFactor_Title.DataPropertyName = "Title1";
            this.TracingFactor_Title.HeaderText = "عامل ردیابی";
            this.TracingFactor_Title.MinimumWidth = 6;
            this.TracingFactor_Title.Name = "TracingFactor_Title";
            // 
            // picAddress
            // 
            this.picAddress.DataPropertyName = "pic";
            this.picAddress.HeaderText = "آدرس تصویر";
            this.picAddress.MinimumWidth = 6;
            this.picAddress.Name = "picAddress";
            this.picAddress.Visible = false;
            // 
            // TracingFactorId
            // 
            this.TracingFactorId.DataPropertyName = "TracingFactorId";
            this.TracingFactorId.HeaderText = "شماره ردیابی";
            this.TracingFactorId.MinimumWidth = 6;
            this.TracingFactorId.Name = "TracingFactorId";
            this.TracingFactorId.Visible = false;
            // 
            // UnitId
            // 
            this.UnitId.DataPropertyName = "UnitId";
            this.UnitId.HeaderText = "شماره واحد";
            this.UnitId.MinimumWidth = 6;
            this.UnitId.Name = "UnitId";
            this.UnitId.Visible = false;
            // 
            // ManageItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(811, 454);
            this.Controls.Add(this.ItemGridView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("IRTerafik", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ManageItem";
            this.Text = "مدیریت کالا/خدمات";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageItem_FormClosed);
            this.Load += new System.EventHandler(this.ManageItem_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).EndInit();
            this.ItemGridView.Init();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddBtnTool;
        private System.Windows.Forms.ToolStripButton DeleteBtnTool;
        private System.Windows.Forms.ToolStripButton EditBtnTool;
        private System.Windows.Forms.ToolStripButton BulkDeleteBtn;
        private System.Windows.Forms.ToolStripButton DeleteCheckedBtn;
        private System.Windows.Forms.ToolStripButton RefreshBtn;
        private CustomGridView ItemGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewImageColumn pic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasTracingFactor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TracingFactor_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn picAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn TracingFactorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitId;
    }
}