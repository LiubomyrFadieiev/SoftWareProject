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
        string login;
        string pass;
        public LogInForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["Auction"].ConnectionString;
            IAuthManager authManager = new AuthManager(connString);
            login = mailText.Text;
            pass = passText.Text;
            (bool, string) message = authManager.LogIn(login, pass);
            if (message.Item1)
            {
                MessageBox.Show(message.Item2, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(message.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
