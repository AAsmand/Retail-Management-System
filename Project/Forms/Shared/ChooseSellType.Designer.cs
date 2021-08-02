namespace Project
{
    partial class ChooseSellType
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
            this.SellTypeGrid = new System.Windows.Forms.DataGridView();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.SellTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellTypeTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SellTypeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // SellTypeGrid
            // 
            this.SellTypeGrid.AllowUserToAddRows = false;
            this.SellTypeGrid.AllowUserToDeleteRows = false;
            this.SellTypeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SellTypeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SellTypeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SellTypeId,
            this.SellTypeTitle});
            this.SellTypeGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.SellTypeGrid.Location = new System.Drawing.Point(0, 0);
            this.SellTypeGrid.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.SellTypeGrid.Name = "SellTypeGrid";
            this.SellTypeGrid.RowHeadersWidth = 51;
            this.SellTypeGrid.Size = new System.Drawing.Size(418, 215);
            this.SellTypeGrid.TabIndex = 0;
            this.SellTypeGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemGrid_CellDoubleClick);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Maroon;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("IRTerafik", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CancelBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CancelBtn.Location = new System.Drawing.Point(117, 222);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(103, 31);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "انصراف";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SelectBtn
            // 
            this.SelectBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.SelectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectBtn.Font = new System.Drawing.Font("IRTerafik", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.SelectBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectBtn.Location = new System.Drawing.Point(8, 222);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(103, 31);
            this.SelectBtn.TabIndex = 3;
            this.SelectBtn.Text = "انتخاب";
            this.SelectBtn.UseVisualStyleBackColor = false;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // SellTypeId
            // 
            this.SellTypeId.DataPropertyName = "SellTypeId";
            this.SellTypeId.HeaderText = "شماره نوع فروش";
            this.SellTypeId.MinimumWidth = 6;
            this.SellTypeId.Name = "SellTypeId";
            this.SellTypeId.ReadOnly = true;
            // 
            // SellTypeTitle
            // 
            this.SellTypeTitle.DataPropertyName = "SellTypeTitle";
            this.SellTypeTitle.HeaderText = "عنوان";
            this.SellTypeTitle.MinimumWidth = 6;
            this.SellTypeTitle.Name = "SellTypeTitle";
            this.SellTypeTitle.ReadOnly = true;
            // 
            // ChooseSellType
            // 
            this.AcceptButton = this.SelectBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(418, 256);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.SellTypeGrid);
            this.Font = new System.Drawing.Font("IRTerafik", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "ChooseSellType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "انتخاب نوع فروش";
            this.Load += new System.EventHandler(this.ChooseSellType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SellTypeGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SellTypeGrid;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellTypeTitle;
    }
}