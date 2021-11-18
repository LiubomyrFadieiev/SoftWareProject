using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL.DTO;

namespace WinForm.Forms
{
    public partial class BidCreateForm : Form
    {
        public int bid;
        public BidCreateForm(GoodDTO good)
        {
            InitializeComponent();
            itemText.Text = good.goodsName;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bid = Int32.Parse(bidText.Text);
        }
    }
}
