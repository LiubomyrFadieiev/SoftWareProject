
namespace WinForm.Forms
{
    partial class BidCreateForm
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
            this.itemLabel = new System.Windows.Forms.Label();
            this.bidLabel = new System.Windows.Forms.Label();
            this.itemText = new System.Windows.Forms.TextBox();
            this.bidText = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.Location = new System.Drawing.Point(166, 84);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(52, 25);
            this.itemLabel.TabIndex = 0;
            this.itemLabel.Text = "Item:";
            // 
            // bidLabel
            // 
            this.bidLabel.AutoSize = true;
            this.bidLabel.Location = new System.Drawing.Point(166, 118);
            this.bidLabel.Name = "bidLabel";
            this.bidLabel.Size = new System.Drawing.Size(82, 25);
            this.bidLabel.TabIndex = 1;
            this.bidLabel.Text = "Your bid:";
            // 
            // itemText
            // 
            this.itemText.Enabled = false;
            this.itemText.Location = new System.Drawing.Point(224, 84);
            this.itemText.Name = "itemText";
            this.itemText.ReadOnly = true;
            this.itemText.Size = new System.Drawing.Size(150, 31);
            this.itemText.TabIndex = 2;
            // 
            // bidText
            // 
            this.bidText.Location = new System.Drawing.Point(254, 118);
            this.bidText.Name = "bidText";
            this.bidText.Size = new System.Drawing.Size(150, 31);
            this.bidText.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(166, 220);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(112, 34);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(292, 220);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 34);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // BidCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 326);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.bidText);
            this.Controls.Add(this.itemText);
            this.Controls.Add(this.bidLabel);
            this.Controls.Add(this.itemLabel);
            this.Name = "BidCreateForm";
            this.Text = "BidCreateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Label bidLabel;
        private System.Windows.Forms.TextBox itemText;
        private System.Windows.Forms.TextBox bidText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}