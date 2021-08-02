namespace Project
{
    partial class ChooseStockRoomForm
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
            this.StockRoomGrid = new System.Windows.Forms.DataGridView();
            this.SRId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StockRoomGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // StockRoomGrid
            // 
            this.StockRoomGrid.AllowUserToAddRows = false;
            this.StockRoomGrid.AllowUserToDeleteRows = false;
            this.StockRoomGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StockRoomGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StockRoomGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SRId,
            this.Title,
            this.Address});
            this.StockRoomGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.StockRoomGrid.Location = new System.Drawing.Point(0, 0);
            this.StockRoomGrid.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.StockRoomGrid.Name = "StockRoomGrid";
            this.StockRoomGrid.RowHeadersWidth = 51;
            this.StockRoomGrid.Size = new System.Drawing.Size(418, 213);
            this.StockRoomGrid.TabIndex = 0;
            this.StockRoomGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StockRoomGrid_CellDoubleClick);
            // 
            // SRId
            // 
            this.SRId.DataPropertyName = "SRId";
            this.SRId.HeaderText = "شماره انبار";
            this.SRId.MinimumWidth = 6;
            this.SRId.Name = "SRId";
            this.SRId.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "عنوان";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "آدرس";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // SelectBtn
            // 
            this.SelectBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.SelectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectBtn.Font = new System.Drawing.Font("IRTerafik", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.SelectBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectBtn.Location = new System.Drawing.Point(4, 221);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(103, 31);
            this.SelectBtn.TabIndex = 1;
            this.SelectBtn.Text = "انتخاب";
            this.SelectBtn.UseVisualStyleBackColor = false;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Maroon;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("IRTerafik", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CancelBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CancelBtn.Location = new System.Drawing.Point(113, 221);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(103, 31);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "انصراف";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ChooseStockRoomForm
            // 
            this.AcceptButton = this.SelectBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(418, 256);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.StockRoomGrid);
            this.Font = new System.Drawing.Font("IRTerafik", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "ChooseStockRoomForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "انتخاب انبار";
            this.Load += new System.EventHandler(this.ChooseItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockRoomGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView StockRoomGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn SRId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}