using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BusinessLogic.Interfaces;
using BusinessLogic.Realization;

namespace WinForm.Forms
{
    public partial class LogInForm : Form
    {
        public string authorisedlogin;
        private IAuthManager authManager;
        public LogInForm(IAuthManager authm)
        {
            InitializeComponent();
            authManager = authm;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["Auction"].ConnectionString;
            string login = mailText.Text;
            string pass = passText.Text;
            (bool, bool) message = authManager.LogIn(login, pass);
            if (message.Item1)
            {
                authorisedlogin = login;
                if (message.Item2)
                {
                    MessageBox.Show("Autorization was successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {
                MessageBox.Show("Invalid credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.No;
            }
        }
    }
}