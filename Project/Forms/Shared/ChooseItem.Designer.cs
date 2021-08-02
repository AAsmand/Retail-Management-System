namespace Project
{
    partial class ChooseItemForm
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
            this.ItemGrid = new System.Windows.Forms.DataGridView();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasTracingFactor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemGrid
            // 
            this.ItemGrid.AllowUserToAddRows = false;
            this.ItemGrid.AllowUserToDeleteRows = false;
            this.ItemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ItemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.Title,
            this.HasTracingFactor});
            this.ItemGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemGrid.Location = new System.Drawing.Point(0, 0);
            this.ItemGrid.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.ItemGrid.Name = "ItemGrid";
            this.ItemGrid.RowHeadersWidth = 51;
            this.ItemGrid.Size = new System.Drawing.Size(418, 215);
            this.ItemGrid.TabIndex = 0;
            this.ItemGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemGrid_CellDoubleClick);
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
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.HeaderText = "شماره کالا";
            this.ItemId.MinimumWidth = 6;
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "عنوان";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // HasTracingFactor
            // 
            this.HasTracingFactor.DataPropertyName = "HasTracingFactor";
            this.HasTracingFactor.HeaderText = "ردیابی";
            this.HasTracingFactor.MinimumWidth = 6;
            this.HasTracingFactor.Name = "HasTracingFactor";
            this.HasTracingFactor.Visible = false;
            // 
            // ChooseItemForm
            // 
            this.AcceptButton = this.SelectBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(418, 256);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.ItemGrid);
            this.Font = new System.Drawing.Font("IRTerafik", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "ChooseItemForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "انتخاب کالا";
            this.Load += new System.EventHandler(this.ChooseItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ItemGrid;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasTracingFactor;
    }
}