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
using WpfApp.ViewModels;

namespace WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for BidWindow.xaml
    /// </summary>
    public partial class BidShowWindow : Window
    {
        BidViewModel vm;
        public BidShowWindow(BidViewModel vm)
        {
            this.vm = vm;
            DataContext = vm;
            InitializeComponent();
            this.Title = vm.Good.goodsName;

            Loaded += BidShowWindow_Loaded;
        }

        private void BidShowWindow_Loaded(object sender, RoutedEventArgs e)
        {
            vm.SeeInfo += () =>
            {
                MessageBox.Show(vm.Good.ToString(), vm.Good.goodsName);
            };
            vm.Open += () =>
            {
                BidWithValidation bv = vm.ReturnCorrectBid();
                BidEditWindow window = new BidEditWindow(bv);
                window.ShowDialog();
                vm.RefreshGrid();
            };
            vm.Buy += () =>
            {
                MessageBox.Show("This item was successfully buyed");
                this.Close();
            };
        }
    }
}
