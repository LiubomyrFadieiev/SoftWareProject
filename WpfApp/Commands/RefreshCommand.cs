using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    // When we have one simple command that does not depent on view info (like refresh DaraGrids)
    public class RefreshCommand : ICommand
    {
        Action execute;
        public RefreshCommand(Action execute)
        {
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
