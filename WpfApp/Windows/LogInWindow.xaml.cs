using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.ViewModels;

namespace WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        private LogInViewModel vm;
        public LogInWindow(LogInViewModel _vm)
        {
            vm = _vm;
            DataContext = vm;
            InitializeComponent();

            Loaded += LogIn_Loaded;
        }

        private void LogIn_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is LogInViewModel lvm)
            {
                lvm.LoginSuccess += () =>
                {
                    MessageBox.Show("Good!", "Welcome!");
                    DialogResult = true;
                };
                lvm.LoginFail += () =>
                {
                    MessageBox.Show("Invalid credentials", "Error");
                };
                lvm.Close += () =>
                {
                    DialogResult = false;
                    this.Close();
                };
            }
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
        }
        public UserDTO GetAuthUser()
        {
            return vm.user;
        }
    }
}
