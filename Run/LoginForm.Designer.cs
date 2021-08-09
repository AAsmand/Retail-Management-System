namespace Project.Forms.User
{
    partial class LoginForm
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
            this.UserTxt = new System.Windows.Forms.TextBox();
            this.PassTxt = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.ExitBtn = new System.Windows.Forms.PictureBox();
            this.LoginBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // UserTxt
            // 
            this.UserTxt.BackColor = System.Drawing.Color.PaleVioletRed;
            this.UserTxt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UserTxt.Location = new System.Drawing.Point(69, 21);
            this.UserTxt.Margin = new System.Windows.Forms.Padding(6);
            this.UserTxt.Name = "UserTxt";
            this.UserTxt.Size = new System.Drawing.Size(220, 36);
            this.UserTxt.TabIndex = 2;
            // 
            // PassTxt
            // 
            this.PassTxt.BackColor = System.Drawing.Color.PaleVioletRed;
            this.PassTxt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.PassTxt.Location = new System.Drawing.Point(69, 69);
            this.PassTxt.Margin = new System.Windows.Forms.Padding(6);
            this.PassTxt.Name = "PassTxt";
            this.PassTxt.PasswordChar = '*';
            this.PassTxt.Size = new System.Drawing.Size(220, 36);
            this.PassTxt.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Run.Properties.Resources._lock;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(29, 72);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 33);
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Run.Properties.Resources.user_1_;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(29, 21);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(37, 36);
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackgroundImage = global::Run.Properties.Resources.PinClipart_com_black_power_fist_clipart_1856543;
            this.ExitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitBtn.Location = new System.Drawing.Point(179, 114);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(68, 66);
            this.ExitBtn.TabIndex = 20;
            this.ExitBtn.TabStop = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackgroundImage = global::Run.Properties.Resources.pngkit_login_icon_png_5186830;
            this.LoginBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBtn.Location = new System.Drawing.Point(83, 114);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(68, 66);
            this.LoginBtn.TabIndex = 19;
            this.LoginBtn.TabStop = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(323, 211);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PassTxt);
            this.Controls.Add(this.UserTxt);
            this.Font = new System.Drawing.Font("B Traffic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ورود کاربر";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox UserTxt;
        private System.Windows.Forms.TextBox PassTxt;
        private System.Windows.Forms.PictureBox ExitBtn;
        private System.Windows.Forms.PictureBox LoginBtn;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}