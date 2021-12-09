using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.Models;

namespace WpfApp.Commands
{
    public class SubmitCommand : ICommand
    {
        BidWithValidation bv;
        public SubmitCommand(BidWithValidation bv)
        {
            this.bv = bv;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return bv["Bid"] == String.Empty;
        }

        public void Execute(object parameter)
        {
            bv.Submit?.Invoke();
        }
    }
}
