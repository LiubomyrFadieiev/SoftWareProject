
namespace WinForm.Forms
{
    partial class BidsShowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BidsShowForm));
            this.bidsDataGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addBidButton = new System.Windows.Forms.ToolStripButton();
            this.infoButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buyButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bidsDataGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bidsDataGrid
            // 
            this.bidsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bidsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fullname,
            this.bid,
            this.insertTime,
            this.lastUpdateTime});
            this.bidsDataGrid.Location = new System.Drawing.Point(12, 42);
            this.bidsDataGrid.Name = "bidsDataGrid";
            this.bidsDataGrid.RowHeadersWidth = 62;
            this.bidsDataGrid.RowTemplate.Height = 33;
            this.bidsDataGrid.Size = new System.Drawing.Size(776, 396);
            this.bidsDataGrid.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.Width = 150;
            // 
            // fullname
            // 
            this.fullname.HeaderText = "Full Name";
            this.fullname.MinimumWidth = 8;
            this.fullname.Name = "fullname";
            this.fullname.Width = 150;
            // 
            // bid
            // 
            this.bid.HeaderText = "Bid";
            this.bid.MinimumWidth = 8;
            this.bid.Name = "bid";
            this.bid.Width = 150;
            // 
            // insertTime
            // 
            this.insertTime.HeaderText = "Insert Time";
            this.insertTime.MinimumWidth = 8;
            this.insertTime.Name = "insertTime";
            this.insertTime.Width = 150;
            // 
            // lastUpdateTime
            // 
            this.lastUpdateTime.HeaderText = "lastUpdateTime";
            this.lastUpdateTime.MinimumWidth = 8;
            this.lastUpdateTime.Name = "lastUpdateTime";
            this.lastUpdateTime.Width = 150;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBidButton,
            this.infoButton,
            this.refreshButton,
            this.toolStripSeparator1,
            this.buyButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 34);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addBidButton
            // 
            this.addBidButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addBidButton.Image = ((System.Drawing.Image)(resources.GetObject("addBidButton.Image")));
            this.addBidButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBidButton.Name = "addBidButton";
            this.addBidButton.Size = new System.Drawing.Size(147, 29);
            this.addBidButton.Text = "Add/Change Bid";
            this.addBidButton.Click += new System.EventHandler(this.addBidButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoButton.Image = ((System.Drawing.Image)(resources.GetObject("infoButton.Image")));
            this.infoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(143, 29);
            this.infoButton.Text = "See Information";
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(74, 29);
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // buyButton
            // 
            this.buyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buyButton.Image = ((System.Drawing.Image)(resources.GetObject("buyButton.Image")));
            this.buyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(85, 29);
            this.buyButton.Text = "Buy item";
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // BidsShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.bidsDataGrid);
            this.Name = "BidsShowForm";
            this.Text = "BidsForm";
            ((System.ComponentModel.ISupportInitialize)(this.bidsDataGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView bidsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn bid;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateTime;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addBidButton;
        private System.Windows.Forms.ToolStripButton infoButton;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buyButton;
    }
}

