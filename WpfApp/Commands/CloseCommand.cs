using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class CloseCommand : ICommand
    {
        private LogInViewModel vm;
        private BidWithValidation bv;
        public CloseCommand(LogInViewModel vm)
        {
            this.vm = vm;
        }
        public CloseCommand(BidWithValidation bv)
        {
            this.bv = bv;
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
            if(vm != null)
            {
                vm.Close?.Invoke();

            }
            else if(bv != null)
            {
                bv.Close?.Invoke();
            }
            
        }
    }
}
