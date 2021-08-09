namespace Project.Forms.User
{
    partial class ManageUsers
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
            this.ManageRolesBtn = new System.Windows.Forms.ToolStripButton();
            this.UserGridView = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtnTool,
            this.DeleteBtnTool,
            this.EditBtnTool,
            this.RefreshBtn,
            this.ManageRolesBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(639, 91);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddBtnTool
            // 
            this.AddBtnTool.Image = global::Utility.Properties.Resources.icons8_plus_64;
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
            this.DeleteBtnTool.Image = global::Utility.Properties.Resources.icons8_delete_64;
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
            this.EditBtnTool.Image = global::Utility.Properties.Resources.icons8_edit_64;
            this.EditBtnTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditBtnTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditBtnTool.Name = "EditBtnTool";
            this.EditBtnTool.Size = new System.Drawing.Size(68, 88);
            this.EditBtnTool.Text = "ویرایش";
            this.EditBtnTool.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.EditBtnTool.Click += new System.EventHandler(this.EditBtnTool_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Image = global::Utility.Properties.Resources.icons8_refresh_love_64;
            this.RefreshBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RefreshBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(68, 88);
            this.RefreshBtn.Text = "بازخوانی";
            this.RefreshBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // ManageRolesBtn
            // 
            this.ManageRolesBtn.Image = global::Utility.Properties.Resources.user_1_;
            this.ManageRolesBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManageRolesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageRolesBtn.Name = "ManageRolesBtn";
            this.ManageRolesBtn.Size = new System.Drawing.Size(114, 88);
            this.ManageRolesBtn.Text = "مدیریت نقش ها";
            this.ManageRolesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // UserGridView
            // 
            this.UserGridView.AllowUserToAddRows = false;
            this.UserGridView.AllowUserToDeleteRows = false;
            this.UserGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UserGridView.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.UserGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.UserId,
            this.FirstName,
            this.LastName,
            this.IsActive});
            this.UserGridView.Location = new System.Drawing.Point(5, 96);
            this.UserGridView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.UserGridView.Name = "UserGridView";
            this.UserGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UserGridView.RowHeadersWidth = 51;
            this.UserGridView.RowTemplate.Height = 24;
            this.UserGridView.Size = new System.Drawing.Size(632, 340);
            this.UserGridView.TabIndex = 5;
            // 
            // Check
            // 
            this.Check.FalseValue = "";
            this.Check.HeaderText = "انتخاب";
            this.Check.IndeterminateValue = "";
            this.Check.MinimumWidth = 6;
            this.Check.Name = "Check";
            this.Check.TrueValue = "1";
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "شماره کاربر";
            this.UserId.MinimumWidth = 6;
            this.UserId.Name = "UserId";
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "Name";
            this.FirstName.HeaderText = "نام";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "نام خانوادگی";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            // 
            // IsActive
            // 
            this.IsActive.DataPropertyName = "IsActive";
            this.IsActive.HeaderText = "فعال";
            this.IsActive.MinimumWidth = 6;
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            this.IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsActive.TrueValue = "T";
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 439);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.UserGridView);
            this.Font = new System.Drawing.Font("B Yekan", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ManageUsers";
            this.Text = "مدیریت کاربران";
            this.Load += new System.EventHandler(this.ManageUsers_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddBtnTool;
        private System.Windows.Forms.ToolStripButton DeleteBtnTool;
        private System.Windows.Forms.ToolStripButton EditBtnTool;
        private System.Windows.Forms.ToolStripButton RefreshBtn;
        private System.Windows.Forms.ToolStripButton ManageRolesBtn;
        private System.Windows.Forms.DataGridView UserGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsActive;
    }
}