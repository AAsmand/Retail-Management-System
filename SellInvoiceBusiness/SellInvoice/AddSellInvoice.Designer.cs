namespace Project
{
    partial class AddSellInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSellInvoice));
            this.label1 = new System.Windows.Forms.Label();
            this.InvoiceDatetxt = new System.Windows.Forms.TextBox();
            this.CustomerTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SellInvoiceItemGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.EditBtnTool = new System.Windows.Forms.ToolStripButton();
            this.SaveBtn = new System.Windows.Forms.ToolStripButton();
            this.SellInvoiceErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalOfferTxt = new System.Windows.Forms.TextBox();
            this.TotalExtras = new System.Windows.Forms.TextBox();
            this.TotalNetPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SellTypeIdTxt = new System.Windows.Forms.TextBox();
            this.SellTypeTitle = new System.Windows.Forms.TextBox();
            this.SellTypeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectItemBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ItemTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockRoomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectStockBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TracingFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectTracingFactorBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Offer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasTracingFactor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SellInvoiceItemGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SellInvoiceErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(996, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ :";
            // 
            // InvoiceDatetxt
            // 
            this.InvoiceDatetxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InvoiceDatetxt.Location = new System.Drawing.Point(763, 97);
            this.InvoiceDatetxt.Name = "InvoiceDatetxt";
            this.InvoiceDatetxt.Size = new System.Drawing.Size(226, 33);
            this.InvoiceDatetxt.TabIndex = 1;
            this.InvoiceDatetxt.Validating += new System.ComponentModel.CancelEventHandler(this.InvoiceDatetxt_Validating);
            // 
            // CustomerTxt
            // 
            this.CustomerTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerTxt.Location = new System.Drawing.Point(441, 97);
            this.CustomerTxt.Name = "CustomerTxt";
            this.CustomerTxt.Size = new System.Drawing.Size(217, 33);
            this.CustomerTxt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(661, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "نام مشتری :";
            // 
            // SellInvoiceItemGridView
            // 
            this.SellInvoiceItemGridView.AllowUserToAddRows = false;
            this.SellInvoiceItemGridView.AllowUserToDeleteRows = false;
            this.SellInvoiceItemGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SellInvoiceItemGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SellInvoiceItemGridView.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.SellInvoiceItemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SellInvoiceItemGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Check,
            this.ItemId,
            this.SelectItemBtn,
            this.ItemTitle,
            this.StockRoomId,
            this.SelectStockBtn,
            this.TracingFactor,
            this.SelectTracingFactorBtn,
            this.Quantity,
            this.Fee,
            this.Total,
            this.Offer,
            this.Extras,
            this.NetPrice,
            this.StockValue,
            this.HasTracingFactor});
            this.SellInvoiceItemGridView.Location = new System.Drawing.Point(0, 135);
            this.SellInvoiceItemGridView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.SellInvoiceItemGridView.Name = "SellInvoiceItemGridView";
            this.SellInvoiceItemGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SellInvoiceItemGridView.RowHeadersWidth = 51;
            this.SellInvoiceItemGridView.RowTemplate.Height = 24;
            this.SellInvoiceItemGridView.Size = new System.Drawing.Size(1062, 299);
            this.SellInvoiceItemGridView.TabIndex = 7;
            this.SellInvoiceItemGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BuyInvoiceItemGridView_CellContentClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditBtnTool,
            this.SaveBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(1062, 91);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // EditBtnTool
            // 
            this.EditBtnTool.Image = global::Utility.Properties.Resources.icons8_delete_64;
            this.EditBtnTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditBtnTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditBtnTool.Name = "EditBtnTool";
            this.EditBtnTool.Size = new System.Drawing.Size(68, 88);
            this.EditBtnTool.Text = "انصراف";
            this.EditBtnTool.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.EditBtnTool.Click += new System.EventHandler(this.EditBtnTool_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Image = global::Utility.Properties.Resources.icons8_save_64;
            this.SaveBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(93, 88);
            this.SaveBtn.Text = "صدور فاکتور";
            this.SaveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SellInvoiceErrorProvider
            // 
            this.SellInvoiceErrorProvider.ContainerControl = this;
            this.SellInvoiceErrorProvider.RightToLeft = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 487);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bindingNavigator1.Size = new System.Drawing.Size(1062, 27);
            this.bindingNavigator1.TabIndex = 9;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(962, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "جمع تخفیف :";
            // 
            // TotalOfferTxt
            // 
            this.TotalOfferTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalOfferTxt.Location = new System.Drawing.Point(718, 442);
            this.TotalOfferTxt.Name = "TotalOfferTxt";
            this.TotalOfferTxt.Size = new System.Drawing.Size(232, 33);
            this.TotalOfferTxt.TabIndex = 14;
            // 
            // TotalExtras
            // 
            this.TotalExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalExtras.Location = new System.Drawing.Point(378, 442);
            this.TotalExtras.Name = "TotalExtras";
            this.TotalExtras.Size = new System.Drawing.Size(232, 33);
            this.TotalExtras.TabIndex = 15;
            // 
            // TotalNetPrice
            // 
            this.TotalNetPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalNetPrice.Location = new System.Drawing.Point(59, 442);
            this.TotalNetPrice.Name = "TotalNetPrice";
            this.TotalNetPrice.Size = new System.Drawing.Size(232, 33);
            this.TotalNetPrice.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(622, 445);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 26);
            this.label5.TabIndex = 17;
            this.label5.Text = "جمع اضافات :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 26);
            this.label6.TabIndex = 18;
            this.label6.Text = "جمع کل :";
            // 
            // SellTypeIdTxt
            // 
            this.SellTypeIdTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SellTypeIdTxt.Location = new System.Drawing.Point(288, 97);
            this.SellTypeIdTxt.Name = "SellTypeIdTxt";
            this.SellTypeIdTxt.Size = new System.Drawing.Size(74, 33);
            this.SellTypeIdTxt.TabIndex = 10;
            this.SellTypeIdTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SRIDTxt_KeyDown);
            // 
            // SellTypeTitle
            // 
            this.SellTypeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SellTypeTitle.Location = new System.Drawing.Point(12, 97);
            this.SellTypeTitle.Name = "SellTypeTitle";
            this.SellTypeTitle.Size = new System.Drawing.Size(250, 33);
            this.SellTypeTitle.TabIndex = 12;
            // 
            // SellTypeBtn
            // 
            this.SellTypeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SellTypeBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SellTypeBtn.Font = new System.Drawing.Font("IRTerafik", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.SellTypeBtn.Location = new System.Drawing.Point(293, 100);
            this.SellTypeBtn.Name = "SellTypeBtn";
            this.SellTypeBtn.Size = new System.Drawing.Size(24, 22);
            this.SellTypeBtn.TabIndex = 19;
            this.SellTypeBtn.Text = "؟";
            this.SellTypeBtn.UseVisualStyleBackColor = false;
            this.SellTypeBtn.Click += new System.EventHandler(this.SellTypeBtn_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "نوع فروش:";
            // 
            // Number
            // 
            this.Number.HeaderText = "ردیف";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
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
            this.ItemId.HeaderText = "کد کالا";
            this.ItemId.MinimumWidth = 6;
            this.ItemId.Name = "ItemId";
            // 
            // SelectItemBtn
            // 
            this.SelectItemBtn.HeaderText = "انتخاب کالا";
            this.SelectItemBtn.MinimumWidth = 6;
            this.SelectItemBtn.Name = "SelectItemBtn";
            this.SelectItemBtn.Text = "؟";
            this.SelectItemBtn.ToolTipText = "ابتدا کد کالا رو انتخاب و روی دکمه کلیک نمایید";
            this.SelectItemBtn.UseColumnTextForButtonValue = true;
            // 
            // ItemTitle
            // 
            this.ItemTitle.DataPropertyName = "ItemTitle";
            this.ItemTitle.HeaderText = "عنوان کالا";
            this.ItemTitle.MinimumWidth = 6;
            this.ItemTitle.Name = "ItemTitle";
            this.ItemTitle.ReadOnly = true;
            // 
            // StockRoomId
            // 
            this.StockRoomId.DataPropertyName = "StockRoomId";
            this.StockRoomId.HeaderText = "انبار";
            this.StockRoomId.MinimumWidth = 6;
            this.StockRoomId.Name = "StockRoomId";
            this.StockRoomId.ReadOnly = true;
            // 
            // SelectStockBtn
            // 
            this.SelectStockBtn.HeaderText = "انتخاب انبار";
            this.SelectStockBtn.MinimumWidth = 6;
            this.SelectStockBtn.Name = "SelectStockBtn";
            this.SelectStockBtn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectStockBtn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SelectStockBtn.Text = "؟";
            this.SelectStockBtn.UseColumnTextForButtonValue = true;
            // 
            // TracingFactor
            // 
            this.TracingFactor.DataPropertyName = "TracingFactor";
            this.TracingFactor.HeaderText = "ردیابی";
            this.TracingFactor.MinimumWidth = 6;
            this.TracingFactor.Name = "TracingFactor";
            this.TracingFactor.ReadOnly = true;
            // 
            // SelectTracingFactorBtn
            // 
            this.SelectTracingFactorBtn.HeaderText = "انتخاب ردیابی";
            this.SelectTracingFactorBtn.MinimumWidth = 6;
            this.SelectTracingFactorBtn.Name = "SelectTracingFactorBtn";
            this.SelectTracingFactorBtn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectTracingFactorBtn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SelectTracingFactorBtn.Text = "؟";
            this.SelectTracingFactorBtn.UseColumnTextForButtonValue = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "تعداد";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            // 
            // Fee
            // 
            this.Fee.DataPropertyName = "Fee";
            this.Fee.HeaderText = "فی";
            this.Fee.MinimumWidth = 6;
            this.Fee.Name = "Fee";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "کل";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Offer
            // 
            this.Offer.DataPropertyName = "Offer";
            this.Offer.HeaderText = "تخفیف";
            this.Offer.MinimumWidth = 6;
            this.Offer.Name = "Offer";
            // 
            // Extras
            // 
            this.Extras.DataPropertyName = "Extras";
            this.Extras.HeaderText = "اضافات";
            this.Extras.MinimumWidth = 6;
            this.Extras.Name = "Extras";
            // 
            // NetPrice
            // 
            this.NetPrice.DataPropertyName = "NetPrice";
            this.NetPrice.HeaderText = "خالص";
            this.NetPrice.MinimumWidth = 6;
            this.NetPrice.Name = "NetPrice";
            this.NetPrice.ReadOnly = true;
            // 
            // StockValue
            // 
            this.StockValue.DataPropertyName = "StockValue";
            this.StockValue.HeaderText = "موجودی";
            this.StockValue.MinimumWidth = 6;
            this.StockValue.Name = "StockValue";
            this.StockValue.Visible = false;
            // 
            // HasTracingFactor
            // 
            this.HasTracingFactor.DataPropertyName = "HasTracingFactor";
            this.HasTracingFactor.FalseValue = "T";
            this.HasTracingFactor.HeaderText = "ردیابی";
            this.HasTracingFactor.MinimumWidth = 6;
            this.HasTracingFactor.Name = "HasTracingFactor";
            this.HasTracingFactor.Visible = false;
            // 
            // AddSellInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1062, 514);
            this.Controls.Add(this.SellTypeBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TotalNetPrice);
            this.Controls.Add(this.TotalExtras);
            this.Controls.Add(this.TotalOfferTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SellTypeTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SellTypeIdTxt);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.SellInvoiceItemGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CustomerTxt);
            this.Controls.Add(this.InvoiceDatetxt);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("IRTerafik", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "AddSellInvoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "فاکتور جدید فروش کالا";
            this.Load += new System.EventHandler(this.AddBuyInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SellInvoiceItemGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SellInvoiceErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InvoiceDatetxt;
        private System.Windows.Forms.TextBox CustomerTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView SellInvoiceItemGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton EditBtnTool;
        private System.Windows.Forms.ToolStripButton SaveBtn;
        private System.Windows.Forms.ErrorProvider SellInvoiceErrorProvider;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TotalNetPrice;
        private System.Windows.Forms.TextBox TotalExtras;
        private System.Windows.Forms.TextBox TotalOfferTxt;
        private System.Windows.Forms.Button SellTypeBtn;
        private System.Windows.Forms.TextBox SellTypeTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SellTypeIdTxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewButtonColumn SelectItemBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockRoomId;
        private System.Windows.Forms.DataGridViewButtonColumn SelectStockBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TracingFactor;
        private System.Windows.Forms.DataGridViewButtonColumn SelectTracingFactorBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Offer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Extras;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasTracingFactor;
    }
}