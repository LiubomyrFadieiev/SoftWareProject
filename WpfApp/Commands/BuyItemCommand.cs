using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class BuyItemCommand : ICommand
    {
        BidViewModel bv;
        public BuyItemCommand(BidViewModel bv)
        {
            this.bv = bv;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !bv.BidList.Exists(b => b.bid >= bv.currentBid.bid && b.user_id != bv.currentBid.user_id);
        }

        public void Execute(object parameter)
        {
            bv.Buy?.Invoke();
        }
    }
}
