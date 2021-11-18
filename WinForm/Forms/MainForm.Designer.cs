namespace WinForm.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.aucTab = new System.Windows.Forms.TabPage();
            this.searchStrip = new System.Windows.Forms.ToolStrip();
            this.searchStripText = new System.Windows.Forms.ToolStripTextBox();
            this.searchStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.searchStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshGoodButton = new System.Windows.Forms.ToolStripButton();
            this.outButton = new System.Windows.Forms.ToolStripButton();
            this.goodsDataGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userTab = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.greetLabel = new System.Windows.Forms.ToolStripTextBox();
            this.refreshBidsButton = new System.Windows.Forms.ToolStripButton();
            this.bidDataGrid = new System.Windows.Forms.DataGridView();
            this.bidGoodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidLUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boughtGoodGrid = new System.Windows.Forms.TabPage();
            this.bgoodsDataGrid = new System.Windows.Forms.DataGridView();
            this.bgId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgSPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgEPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgLUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceGoods = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.refreshBGoodButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.aucTab.SuspendLayout();
            this.searchStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goodsDataGrid)).BeginInit();
            this.userTab.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bidDataGrid)).BeginInit();
            this.boughtGoodGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgoodsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGoods)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.aucTab);
            this.tabControl1.Controls.Add(this.userTab);
            this.tabControl1.Controls.Add(this.boughtGoodGrid);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // aucTab
            // 
            this.aucTab.Controls.Add(this.searchStrip);
            this.aucTab.Controls.Add(this.goodsDataGrid);
            this.aucTab.Location = new System.Drawing.Point(4, 34);
            this.aucTab.Name = "aucTab";
            this.aucTab.Padding = new System.Windows.Forms.Padding(3);
            this.aucTab.Size = new System.Drawing.Size(780, 400);
            this.aucTab.TabIndex = 0;
            this.aucTab.Text = "Auctions";
            this.aucTab.UseVisualStyleBackColor = true;
            // 
            // searchStrip
            // 
            this.searchStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.searchStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchStripText,
            this.searchStripComboBox,
            this.searchStripButton,
            this.refreshGoodButton,
            this.outButton});
            this.searchStrip.Location = new System.Drawing.Point(3, 3);
            this.searchStrip.Name = "searchStrip";
            this.searchStrip.Size = new System.Drawing.Size(774, 34);
            this.searchStrip.TabIndex = 1;
            this.searchStrip.Text = "toolStrip1";
            // 
            // searchStripText
            // 
            this.searchStripText.Name = "searchStripText";
            this.searchStripText.Size = new System.Drawing.Size(200, 34);
            // 
            // searchStripComboBox
            // 
            this.searchStripComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Name",
            "Description"});
            this.searchStripComboBox.Items.AddRange(new object[] {
            "Name",
            "Description"});
            this.searchStripComboBox.Name = "searchStripComboBox";
            this.searchStripComboBox.Size = new System.Drawing.Size(121, 34);
            // 
            // searchStripButton
            // 
            this.searchStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.searchStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchStripButton.Margin = new System.Windows.Forms.Padding(0, 2, 180, 3);
            this.searchStripButton.Name = "searchStripButton";
            this.searchStripButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.searchStripButton.Size = new System.Drawing.Size(68, 29);
            this.searchStripButton.Text = "Search";
            this.searchStripButton.Click += new System.EventHandler(this.searchStripButton_Click);
            // 
            // refreshGoodButton
            // 
            this.refreshGoodButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshGoodButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshGoodButton.Image")));
            this.refreshGoodButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshGoodButton.Name = "refreshGoodButton";
            this.refreshGoodButton.Size = new System.Drawing.Size(74, 29);
            this.refreshGoodButton.Text = "Refresh";
            // 
            // outButton
            // 
            this.outButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.outButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.outButton.Name = "outButton";
            this.outButton.Size = new System.Drawing.Size(78, 29);
            this.outButton.Text = "Log out";
            this.outButton.Click += new System.EventHandler(this.outButton_Click);
            // 
            // goodsDataGrid
            // 
            this.goodsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.goodsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.desc,
            this.startPrice,
            this.insertTime,
            this.lastUpdateTime});
            this.goodsDataGrid.Location = new System.Drawing.Point(8, 40);
            this.goodsDataGrid.Name = "goodsDataGrid";
            this.goodsDataGrid.RowHeadersWidth = 62;
            this.goodsDataGrid.RowTemplate.Height = 33;
            this.goodsDataGrid.Size = new System.Drawing.Size(766, 354);
            this.goodsDataGrid.TabIndex = 0;
            this.goodsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.goodsDataGrid_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "good_id";
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // name
            // 
            this.name.DataPropertyName = "goodsName";
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 8;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // desc
            // 
            this.desc.DataPropertyName = "goodsDesc";
            this.desc.HeaderText = "Description";
            this.desc.MinimumWidth = 8;
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Width = 150;
            // 
            // startPrice
            // 
            this.startPrice.DataPropertyName = "startPrice";
            this.startPrice.HeaderText = "Start Price";
            this.startPrice.MinimumWidth = 8;
            this.startPrice.Name = "startPrice";
            this.startPrice.ReadOnly = true;
            this.startPrice.Width = 130;
            // 
            // insertTime
            // 
            this.insertTime.DataPropertyName = "insertTime";
            this.insertTime.HeaderText = "Insert Time";
            this.insertTime.MinimumWidth = 8;
            this.insertTime.Name = "insertTime";
            this.insertTime.ReadOnly = true;
            this.insertTime.Width = 150;
            // 
            // lastUpdateTime
            // 
            this.lastUpdateTime.DataPropertyName = "lastUpdateTime";
            this.lastUpdateTime.HeaderText = "Last Update Time";
            this.lastUpdateTime.MinimumWidth = 8;
            this.lastUpdateTime.Name = "lastUpdateTime";
            this.lastUpdateTime.ReadOnly = true;
            this.lastUpdateTime.Width = 230;
            // 
            // userTab
            // 
            this.userTab.Controls.Add(this.toolStrip1);
            this.userTab.Controls.Add(this.bidDataGrid);
            this.userTab.Location = new System.Drawing.Point(4, 34);
            this.userTab.Name = "userTab";
            this.userTab.Padding = new System.Windows.Forms.Padding(3);
            this.userTab.Size = new System.Drawing.Size(780, 400);
            this.userTab.TabIndex = 1;
            this.userTab.Text = "Your Bids";
            this.userTab.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.greetLabel,
            this.refreshBidsButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(774, 34);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // greetLabel
            // 
            this.greetLabel.Name = "greetLabel";
            this.greetLabel.ReadOnly = true;
            this.greetLabel.Size = new System.Drawing.Size(300, 34);
            this.greetLabel.Text = "Hello, ";
            // 
            // refreshBidsButton
            // 
            this.refreshBidsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshBidsButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshBidsButton.Image")));
            this.refreshBidsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshBidsButton.Name = "refreshBidsButton";
            this.refreshBidsButton.Size = new System.Drawing.Size(74, 29);
            this.refreshBidsButton.Text = "Refresh";
            this.refreshBidsButton.Click += new System.EventHandler(this.refreshBidsButton_Click);
            // 
            // bidDataGrid
            // 
            this.bidDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bidDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bidGoodId,
            this.bidName,
            this.bidDesc,
            this.bidPrice,
            this.bidBid,
            this.bidIT,
            this.bidLUT});
            this.bidDataGrid.Location = new System.Drawing.Point(8, 41);
            this.bidDataGrid.Name = "bidDataGrid";
            this.bidDataGrid.RowHeadersWidth = 62;
            this.bidDataGrid.RowTemplate.Height = 33;
            this.bidDataGrid.Size = new System.Drawing.Size(766, 353);
            this.bidDataGrid.TabIndex = 1;
            this.bidDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bidDataGrid_CellContentClick);
            // 
            // bidGoodId
            // 
            this.bidGoodId.HeaderText = "ID";
            this.bidGoodId.MinimumWidth = 8;
            this.bidGoodId.Name = "bidGoodId";
            this.bidGoodId.ReadOnly = true;
            this.bidGoodId.Width = 150;
            // 
            // bidName
            // 
            this.bidName.HeaderText = "Name";
            this.bidName.MinimumWidth = 8;
            this.bidName.Name = "bidName";
            this.bidName.ReadOnly = true;
            this.bidName.Width = 150;
            // 
            // bidDesc
            // 
            this.bidDesc.HeaderText = "Description";
            this.bidDesc.MinimumWidth = 8;
            this.bidDesc.Name = "bidDesc";
            this.bidDesc.ReadOnly = true;
            this.bidDesc.Width = 150;
            // 
            // bidPrice
            // 
            this.bidPrice.HeaderText = "Start Price";
            this.bidPrice.MinimumWidth = 8;
            this.bidPrice.Name = "bidPrice";
            this.bidPrice.ReadOnly = true;
            this.bidPrice.Width = 150;
            // 
            // bidBid
            // 
            this.bidBid.HeaderText = "Bid";
            this.bidBid.MinimumWidth = 8;
            this.bidBid.Name = "bidBid";
            this.bidBid.ReadOnly = true;
            this.bidBid.Width = 150;
            // 
            // bidIT
            // 
            this.bidIT.HeaderText = "Insert TIme";
            this.bidIT.MinimumWidth = 8;
            this.bidIT.Name = "bidIT";
            this.bidIT.ReadOnly = true;
            this.bidIT.Width = 150;
            // 
            // bidLUT
            // 
            this.bidLUT.HeaderText = "Last Update Time";
            this.bidLUT.MinimumWidth = 8;
            this.bidLUT.Name = "bidLUT";
            this.bidLUT.ReadOnly = true;
            this.bidLUT.Width = 150;
            // 
            // boughtGoodGrid
            // 
            this.boughtGoodGrid.Controls.Add(this.toolStrip2);
            this.boughtGoodGrid.Controls.Add(this.bgoodsDataGrid);
            this.boughtGoodGrid.Location = new System.Drawing.Point(4, 34);
            this.boughtGoodGrid.Name = "boughtGoodGrid";
            this.boughtGoodGrid.Size = new System.Drawing.Size(780, 400);
            this.boughtGoodGrid.TabIndex = 2;
            this.boughtGoodGrid.Text = "My goods";
            this.boughtGoodGrid.UseVisualStyleBackColor = true;
            // 
            // bgoodsDataGrid
            // 
            this.bgoodsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bgoodsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bgId,
            this.bgName,
            this.bgDesc,
            this.bgSPrice,
            this.bgEPrice,
            this.bgIT,
            this.bgLUT});
            this.bgoodsDataGrid.Location = new System.Drawing.Point(8, 43);
            this.bgoodsDataGrid.Name = "bgoodsDataGrid";
            this.bgoodsDataGrid.RowHeadersWidth = 62;
            this.bgoodsDataGrid.RowTemplate.Height = 33;
            this.bgoodsDataGrid.Size = new System.Drawing.Size(769, 354);
            this.bgoodsDataGrid.TabIndex = 0;
            // 
            // bgId
            // 
            this.bgId.HeaderText = "ID";
            this.bgId.MinimumWidth = 8;
            this.bgId.Name = "bgId";
            this.bgId.ReadOnly = true;
            this.bgId.Width = 150;
            // 
            // bgName
            // 
            this.bgName.HeaderText = "Name";
            this.bgName.MinimumWidth = 8;
            this.bgName.Name = "bgName";
            this.bgName.ReadOnly = true;
            this.bgName.Width = 150;
            // 
            // bgDesc
            // 
            this.bgDesc.HeaderText = "Description";
            this.bgDesc.MinimumWidth = 8;
            this.bgDesc.Name = "bgDesc";
            this.bgDesc.ReadOnly = true;
            this.bgDesc.Width = 150;
            // 
            // bgSPrice
            // 
            this.bgSPrice.HeaderText = "Start Price";
            this.bgSPrice.MinimumWidth = 8;
            this.bgSPrice.Name = "bgSPrice";
            this.bgSPrice.ReadOnly = true;
            this.bgSPrice.Width = 150;
            // 
            // bgEPrice
            // 
            this.bgEPrice.HeaderText = "End Price";
            this.bgEPrice.MinimumWidth = 8;
            this.bgEPrice.Name = "bgEPrice";
            this.bgEPrice.ReadOnly = true;
            this.bgEPrice.Width = 150;
            // 
            // bgIT
            // 
            this.bgIT.HeaderText = "Insert Time";
            this.bgIT.MinimumWidth = 8;
            this.bgIT.Name = "bgIT";
            this.bgIT.ReadOnly = true;
            this.bgIT.Width = 150;
            // 
            // bgLUT
            // 
            this.bgLUT.HeaderText = "Last Insert Time";
            this.bgLUT.MinimumWidth = 8;
            this.bgLUT.Name = "bgLUT";
            this.bgLUT.ReadOnly = true;
            this.bgLUT.Width = 150;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshBGoodButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(780, 34);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // refreshBGoodButton
            // 
            this.refreshBGoodButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshBGoodButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshBGoodButton.Image")));
            this.refreshBGoodButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshBGoodButton.Name = "refreshBGoodButton";
            this.refreshBGoodButton.Size = new System.Drawing.Size(74, 29);
            this.refreshBGoodButton.Text = "Refresh";
            this.refreshBGoodButton.Click += new System.EventHandler(this.refreshBGoodButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Trading Company";
            this.tabControl1.ResumeLayout(false);
            this.aucTab.ResumeLayout(false);
            this.aucTab.PerformLayout();
            this.searchStrip.ResumeLayout(false);
            this.searchStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goodsDataGrid)).EndInit();
            this.userTab.ResumeLayout(false);
            this.userTab.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bidDataGrid)).EndInit();
            this.boughtGoodGrid.ResumeLayout(false);
            this.boughtGoodGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgoodsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGoods)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage aucTab;
        private System.Windows.Forms.DataGridView goodsDataGrid;
        private System.Windows.Forms.TabPage userTab;
        private System.Windows.Forms.BindingSource bindingSourceGoods;
        private System.Windows.Forms.ToolStrip searchStrip;
        private System.Windows.Forms.ToolStripTextBox searchStripText;
        private System.Windows.Forms.ToolStripComboBox searchStripComboBox;
        private System.Windows.Forms.ToolStripButton searchStripButton;
        private System.Windows.Forms.DataGridView bidDataGrid;
        private System.Windows.Forms.TabPage boughtGoodGrid;
        private System.Windows.Forms.DataGridView bgoodsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn startPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidGoodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidLUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn bgId;
        private System.Windows.Forms.DataGridViewTextBoxColumn bgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bgDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn bgSPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn bgEPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn bgIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn bgLUT;
        private System.Windows.Forms.ToolStripButton outButton;
        private System.Windows.Forms.ToolStripButton refreshGoodButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox greetLabel;
        private System.Windows.Forms.ToolStripButton refreshBidsButton;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton refreshBGoodButton;
    }
}