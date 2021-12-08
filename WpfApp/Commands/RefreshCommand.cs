using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class RefreshCommand : ICommand
    {
        MainWindowViewModel vm;
        Action execute;
        public RefreshCommand(MainWindowViewModel vm, Action execute)
        {
            this.vm = vm;
            this.execute = execute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke();
        }
    }
}
