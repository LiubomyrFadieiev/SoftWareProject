using BusinessLogic.Interfaces;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp.ViewModels
{
    public class BidViewModel : INotifyPropertyChanged
    {
        // DTOs and Manager 
        private readonly IAuctionManager aucmanager;
        private readonly GoodDTO good;
        private readonly UserDTO user;
        // Properties and INotifyPropertyChanged
        private List<BidDTO> bidList;
        public List<BidDTO> BidList
        {
            get => bidList;
            set
            {
                bidList = value;
                OnPropertyChanged(nameof(BidList));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        // Command functionality
        public Action AddItem;
        public Action SeeInfo;
        public Action Refresh;
        public Predicate<bool?> CanBuy;
        public Action Buy;
        // constructor and misc.
        public BidViewModel(GoodDTO good, UserDTO user, IAuctionManager aucmanager)
        {
            this.good = good;
            this.user = user;
            this.aucmanager = aucmanager;
            BidList = aucmanager.GetGoodsBids(good);

            
        }
    }
}
