
namespace WinForm.Forms
{
    partial class LogInForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mailLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.mailText = new System.Windows.Forms.TextBox();
            this.passText = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mailLabel
            // 
            this.mailLabel.AutoSize = true;
            this.mailLabel.Location = new System.Drawing.Point(62, 120);
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size(61, 25);
            this.mailLabel.TabIndex = 0;
            this.mailLabel.Text = "E-mail";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(62, 182);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(87, 25);
            this.passLabel.TabIndex = 1;
            this.passLabel.Text = "Password";
            // 
            // mailText
            // 
            this.mailText.Location = new System.Drawing.Point(62, 148);
            this.mailText.Name = "mailText";
            this.mailText.Size = new System.Drawing.Size(315, 31);
            this.mailText.TabIndex = 2;
            this.mailText.Text = "adventuretime@gmail.com";
            // 
            // passText
            // 
            this.passText.Location = new System.Drawing.Point(62, 210);
            this.passText.Name = "passText";
            this.passText.Size = new System.Drawing.Size(315, 31);
            this.passText.TabIndex = 3;
            this.passText.Text = "12345678";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(62, 272);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(315, 34);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Log In";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 450);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.mailText);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.mailLabel);
            this.Name = "LogInForm";
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mailLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.TextBox mailText;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.Button submitButton;
    }
}
