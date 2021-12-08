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
        }
    }
}
