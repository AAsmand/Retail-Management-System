namespace Project.Forms.User
{
    partial class AddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            this.label1 = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PicAddressTxt = new System.Windows.Forms.TextBox();
            this.SelectPic = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LastNameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BirthdayTxt = new System.Windows.Forms.TextBox();
            this.IsActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.RolesGridView = new System.Windows.Forms.DataGridView();
            this.RoleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectRoleBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.UserErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.RolesNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RolesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RolesNavigator)).BeginInit();
            this.RolesNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RolesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(753, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "نام";
            // 
            // NameTxt
            // 
            this.NameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTxt.Location = new System.Drawing.Point(369, 50);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(317, 30);
            this.NameTxt.TabIndex = 1;
            this.NameTxt.TextChanged += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddBtn.Location = new System.Drawing.Point(12, 528);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(185, 45);
            this.AddBtn.TabIndex = 8;
            this.AddBtn.Text = "افزودن";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(733, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "تصویر";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(45, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // PicAddressTxt
            // 
            this.PicAddressTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PicAddressTxt.Location = new System.Drawing.Point(369, 297);
            this.PicAddressTxt.Name = "PicAddressTxt";
            this.PicAddressTxt.Size = new System.Drawing.Size(317, 30);
            this.PicAddressTxt.TabIndex = 6;
            // 
            // SelectPic
            // 
            this.SelectPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectPic.Location = new System.Drawing.Point(287, 297);
            this.SelectPic.Name = "SelectPic";
            this.SelectPic.Size = new System.Drawing.Size(76, 32);
            this.SelectPic.TabIndex = 18;
            this.SelectPic.Text = "انتخاب";
            this.SelectPic.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(702, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "نام خانوادگی";
            // 
            // LastNameTxt
            // 
            this.LastNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LastNameTxt.Location = new System.Drawing.Point(369, 95);
            this.LastNameTxt.Name = "LastNameTxt";
            this.LastNameTxt.Size = new System.Drawing.Size(317, 30);
            this.LastNameTxt.TabIndex = 2;
            this.LastNameTxt.TextChanged += new System.EventHandler(this.LastNameTxt_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(715, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "نام کاربری";
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameTxt.Location = new System.Drawing.Point(369, 140);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(317, 30);
            this.UsernameTxt.TabIndex = 3;
            this.UsernameTxt.TextChanged += new System.EventHandler(this.UsernameTxt_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(715, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 23);
            this.label6.TabIndex = 29;
            this.label6.Text = "کلمه عبور";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTxt.Location = new System.Drawing.Point(369, 185);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '*';
            this.PasswordTxt.Size = new System.Drawing.Size(317, 30);
            this.PasswordTxt.TabIndex = 4;
            this.PasswordTxt.TextChanged += new System.EventHandler(this.PasswordTxt_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(713, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 23);
            this.label7.TabIndex = 31;
            this.label7.Text = "تاریخ تولد";
            // 
            // BirthdayTxt
            // 
            this.BirthdayTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BirthdayTxt.Location = new System.Drawing.Point(369, 230);
            this.BirthdayTxt.Name = "BirthdayTxt";
            this.BirthdayTxt.Size = new System.Drawing.Size(317, 30);
            this.BirthdayTxt.TabIndex = 5;
            // 
            // IsActiveCheckBox
            // 
            this.IsActiveCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsActiveCheckBox.AutoSize = true;
            this.IsActiveCheckBox.Location = new System.Drawing.Point(127, 486);
            this.IsActiveCheckBox.Name = "IsActiveCheckBox";
            this.IsActiveCheckBox.Size = new System.Drawing.Size(70, 27);
            this.IsActiveCheckBox.TabIndex = 7;
            this.IsActiveCheckBox.Text = "    فعال";
            this.IsActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // RolesGridView
            // 
            this.RolesGridView.AllowUserToAddRows = false;
            this.RolesGridView.AllowUserToDeleteRows = false;
            this.RolesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RolesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RolesGridView.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.RolesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RolesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoleId,
            this.SelectRoleBtn,
            this.RoleName});
            this.RolesGridView.Location = new System.Drawing.Point(231, 358);
            this.RolesGridView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RolesGridView.Name = "RolesGridView";
            this.RolesGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RolesGridView.RowHeadersWidth = 51;
            this.RolesGridView.RowTemplate.Height = 24;
            this.RolesGridView.Size = new System.Drawing.Size(455, 188);
            this.RolesGridView.TabIndex = 33;
            this.RolesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RolesGridView_CellContentClick);
            // 
            // RoleId
            // 
            this.RoleId.DataPropertyName = "RoleId";
            this.RoleId.FillWeight = 109.8931F;
            this.RoleId.HeaderText = "شماره نقش";
            this.RoleId.MinimumWidth = 6;
            this.RoleId.Name = "RoleId";
            // 
            // SelectRoleBtn
            // 
            this.SelectRoleBtn.FillWeight = 80.21391F;
            this.SelectRoleBtn.HeaderText = "انتخاب";
            this.SelectRoleBtn.MinimumWidth = 6;
            this.SelectRoleBtn.Name = "SelectRoleBtn";
            this.SelectRoleBtn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectRoleBtn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SelectRoleBtn.Text = "انتخاب";
            this.SelectRoleBtn.UseColumnTextForButtonValue = true;
            // 
            // RoleName
            // 
            this.RoleName.DataPropertyName = "RoleName";
            this.RoleName.FillWeight = 109.8931F;
            this.RoleName.HeaderText = "عنوان";
            this.RoleName.MinimumWidth = 6;
            this.RoleName.Name = "RoleName";
            this.RoleName.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(729, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "نقش ها";
            // 
            // UserErrorProvider
            // 
            this.UserErrorProvider.ContainerControl = this;
            // 
            // RolesNavigator
            // 
            this.RolesNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.RolesNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RolesNavigator.AutoSize = false;
            this.RolesNavigator.CountItem = null;
            this.RolesNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.RolesNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.RolesNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.RolesNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RolesNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.RolesNavigator.Location = new System.Drawing.Point(231, 546);
            this.RolesNavigator.MoveFirstItem = null;
            this.RolesNavigator.MoveLastItem = null;
            this.RolesNavigator.MoveNextItem = null;
            this.RolesNavigator.MovePreviousItem = null;
            this.RolesNavigator.Name = "RolesNavigator";
            this.RolesNavigator.PositionItem = null;
            this.RolesNavigator.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RolesNavigator.Size = new System.Drawing.Size(455, 27);
            this.RolesNavigator.TabIndex = 35;
            this.RolesNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(816, 582);
            this.Controls.Add(this.RolesNavigator);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RolesGridView);
            this.Controls.Add(this.IsActiveCheckBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BirthdayTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsernameTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LastNameTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PicAddressTxt);
            this.Controls.Add(this.SelectPic);
            this.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddUser";
            this.Text = "افزودن کاربر";
            this.Load += new System.EventHandler(this.AddUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RolesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RolesNavigator)).EndInit();
            this.RolesNavigator.ResumeLayout(false);
            this.RolesNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RolesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox PicAddressTxt;
        private System.Windows.Forms.Button SelectPic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LastNameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BirthdayTxt;
        private System.Windows.Forms.CheckBox IsActiveCheckBox;
        private System.Windows.Forms.DataGridView RolesGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider UserErrorProvider;
        private System.Windows.Forms.BindingNavigator RolesNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource RolesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleId;
        private System.Windows.Forms.DataGridViewButtonColumn SelectRoleBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleName;
    }
}