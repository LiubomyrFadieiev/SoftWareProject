using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class OpenItemCommand : ICommand
    {
        private MainWindowViewModel mvm;
        private BidViewModel bvm;
        public OpenItemCommand(MainWindowViewModel mvm)
        {
            this.mvm = mvm;
        }
        public OpenItemCommand(BidViewModel bvm)
        {
            this.bvm = bvm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (mvm != null)
            {
                if (mvm.SelectedTab.Header.ToString() == "Your Bids")
                {
                    return mvm.SelectedBid != null;
                }
                else if (mvm.SelectedTab.Header.ToString() == "Auctions")
                {
                    return mvm.SelectedGood != null;
                }
            }
            if (bvm != null)
            {
                return true;
            }
            throw new Exception();
        }

        public void Execute(object parameter)
        {
            if(mvm != null)
            {
                if(mvm.SelectedTab.Header.ToString() == "Your Bids")
                {
                    mvm.OpenFromBids?.Invoke();
                }
                else if(mvm.SelectedTab.Header.ToString() == "Auctions")
                {
                    mvm.OpenFromGoods?.Invoke();
                }
            }
            else if(bvm != null)
            {
                bvm.Open?.Invoke();
            }
        }
    }
}
