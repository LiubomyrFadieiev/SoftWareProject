using DAL.DTO;
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
using WPFUserControl.ViewModel;

namespace WPFUserControl.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel vm;
        public MainWindow(MainWindowViewModel vm)
        {
            this.vm = vm;
            this.DataContext = vm;
            InitializeComponent();

            Loaded += Main_Loaded;
        }
        private void Main_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(vm.SearchString);
        }
    }
}
