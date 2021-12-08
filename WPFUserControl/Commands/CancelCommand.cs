using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPFUserControl.ViewModel;

namespace WPFUserControl.Commands
{
    public class CancelCommand : ICommand
    {
        private LogInViewModel vm;
        public CancelCommand(LogInViewModel vm)
        {
            this.vm = vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vm.Close?.Invoke();
        }
    }
}
