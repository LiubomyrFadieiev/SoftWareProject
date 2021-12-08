﻿using DAL.DTO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel vm;
        public bool isLoggedOut { get; set; }
        public MainWindow(MainWindowViewModel vm)
        {
            isLoggedOut = false;
            this.vm = vm;
            this.DataContext = vm;
            InitializeComponent();

            Loaded += Main_Loaded;
        }
        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            vm.open += () =>
            {
                BidViewModel bidViewModel = vm.ReturnBidModel();
                BidShowWindow bsw = new BidShowWindow(bidViewModel);
                bsw.ShowDialog();
            };
            vm.logOut += () =>
            {
                MessageBox.Show("You have been successfully logged out.", "Goodbye!");
                isLoggedOut = true;
            };
        }
    }
}
