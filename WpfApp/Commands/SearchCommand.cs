using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class SearchCommand : ICommand
    {
        MainWindowViewModel vm;

        public event EventHandler CanExecuteChanged;
        public SearchCommand(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vm.Search?.Invoke();
        }
    }
}
