using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Models;

namespace WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for BidEditWindow.xaml
    /// </summary>
    public partial class BidEditWindow : Window
    {
        private BidWithValidation bv;
        public BidEditWindow(BidWithValidation bv)
        {
            this.bv = bv;
            DataContext = bv;
            InitializeComponent();

            Loaded += BidEditWindow_Loaded;
        }

        private void BidEditWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bv.Submit += () =>
            {
                MessageBox.Show("Your bid successfully updated.","Success!");
                DialogResult = true;
                this.Close();
            };
            bv.Close += () =>
            {
                DialogResult = false;
                this.Close();
            };
        }
    }
}
