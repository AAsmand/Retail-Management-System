namespace Project
{
    partial class AddItem
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
            this.Titletxt = new System.Windows.Forms.TextBox();
            this.Descriptiontxt = new System.Windows.Forms.RichTextBox();
            this.UnitCombo = new System.Windows.Forms.ComboBox();
            this.TracingCombo = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PicAddressTxt = new System.Windows.Forms.TextBox();
            this.SelectPic = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TitleError = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.HasTracingFactor = new System.Windows.Forms.CheckBox();
            this.AddItemErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddItemErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // Titletxt
            // 
            this.Titletxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Titletxt.Location = new System.Drawing.Point(334, 3);
            this.Titletxt.Name = "Titletxt";
            this.Titletxt.Size = new System.Drawing.Size(654, 32);
            this.Titletxt.TabIndex = 0;
            this.Titletxt.Validating += new System.ComponentModel.CancelEventHandler(this.Titletxt_Validating);
            // 
            // Descriptiontxt
            // 
            this.Descriptiontxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Descriptiontxt.Location = new System.Drawing.Point(334, 41);
            this.Descriptiontxt.Name = "Descriptiontxt";
            this.Descriptiontxt.Size = new System.Drawing.Size(654, 260);
            this.Descriptiontxt.TabIndex = 1;
            this.Descriptiontxt.Text = "";
            // 
            // UnitCombo
            // 
            this.UnitCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnitCombo.FormattingEnabled = true;
            this.UnitCombo.Location = new System.Drawing.Point(334, 347);
            this.UnitCombo.Name = "UnitCombo";
            this.UnitCombo.Size = new System.Drawing.Size(654, 32);
            this.UnitCombo.TabIndex = 2;
            // 
            // TracingCombo
            // 
            this.TracingCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TracingCombo.FormattingEnabled = true;
            this.TracingCombo.Location = new System.Drawing.Point(334, 307);
            this.TracingCombo.Name = "TracingCombo";
            this.TracingCombo.Size = new System.Drawing.Size(654, 32);
            this.TracingCombo.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 392);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(222, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PicAddressTxt
            // 
            this.PicAddressTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicAddressTxt.Location = new System.Drawing.Point(334, 392);
            this.PicAddressTxt.Name = "PicAddressTxt";
            this.PicAddressTxt.Size = new System.Drawing.Size(654, 32);
            this.PicAddressTxt.TabIndex = 5;
            // 
            // SelectPic
            // 
            this.SelectPic.Location = new System.Drawing.Point(231, 392);
            this.SelectPic.Name = "SelectPic";
            this.SelectPic.Size = new System.Drawing.Size(97, 32);
            this.SelectPic.TabIndex = 6;
            this.SelectPic.Text = "انتخاب";
            this.SelectPic.UseVisualStyleBackColor = true;
            this.SelectPic.Click += new System.EventHandler(this.SelectPic_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.AddBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddBtn.Location = new System.Drawing.Point(3, 627);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(222, 45);
            this.AddBtn.TabIndex = 7;
            this.AddBtn.Text = "افزودن";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1044, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "عنوان";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1026, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "توضیحات";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1025, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "واحد مرجع";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1017, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "عامل ردیابی";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1043, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "تصویر";
            // 
            // TitleError
            // 
            this.TitleError.AutoSize = true;
            this.TitleError.ForeColor = System.Drawing.Color.Red;
            this.TitleError.Location = new System.Drawing.Point(566, 88);
            this.TitleError.Name = "TitleError";
            this.TitleError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TitleError.Size = new System.Drawing.Size(0, 24);
            this.TitleError.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.53985F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.46015F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 227F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Titletxt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.AddBtn, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Descriptiontxt, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.UnitCombo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.TracingCombo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PicAddressTxt, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.SelectPic, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.HasTracingFactor, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.35294F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.64706F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 235F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1085, 675);
            this.tableLayoutPanel1.TabIndex = 14;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // HasTracingFactor
            // 
            this.HasTracingFactor.AutoSize = true;
            this.HasTracingFactor.Location = new System.Drawing.Point(274, 307);
            this.HasTracingFactor.Name = "HasTracingFactor";
            this.HasTracingFactor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HasTracingFactor.Size = new System.Drawing.Size(54, 28);
            this.HasTracingFactor.TabIndex = 14;
            this.HasTracingFactor.Text = "فعال";
            this.HasTracingFactor.UseVisualStyleBackColor = true;
            this.HasTracingFactor.CheckedChanged += new System.EventHandler(this.HasTracingFactor_CheckedChanged);
            // 
            // AddItemErrorProvider
            // 
            this.AddItemErrorProvider.ContainerControl = this;
            this.AddItemErrorProvider.RightToLeft = true;
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1085, 675);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.TitleError);
            this.Font = new System.Drawing.Font("IRMitra", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddItem";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "افزودن کالا/خدمت";
            this.Load += new System.EventHandler(this.AddItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddItemErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Titletxt;
        private System.Windows.Forms.RichTextBox Descriptiontxt;
        private System.Windows.Forms.ComboBox UnitCombo;
        private System.Windows.Forms.ComboBox TracingCombo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox PicAddressTxt;
        private System.Windows.Forms.Button SelectPic;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TitleError;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ErrorProvider AddItemErrorProvider;
        private System.Windows.Forms.CheckBox HasTracingFactor;
    }
}