using BusinessLogic.Interfaces;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class BidViewModel : INotifyPropertyChanged
    {
        // DTOs and Manager 
        private readonly IAuctionManager aucmanager;
        public GoodDTO Good { get; }
        private readonly UserDTO user;
        public BidDTO currentBid { private set; get; }
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
        protected void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        // Command functionality
        public Action Open;
        public Action SeeInfo;
        public Action Refresh;
        public Predicate<bool?> CanBuy;
        public Action Buy;
        public RefreshCommand RefreshBidCommand { get; }
        public SeeInfoCommand SeeInfoCommand { get; }
        public OpenItemCommand EditBidCommand { get; }
        public BuyItemCommand BuyItemCommand { get; }
        // constructor and misc.
        public BidViewModel(GoodDTO good, UserDTO user, IAuctionManager aucmanager)
        {
            this.aucmanager = aucmanager;
            this.Good = good;
            this.user = user;
            BidList = aucmanager.GetGoodsBids(good);
            currentBid = BidList.Find(b => b.user_id == user.user_id);
            RefreshBidCommand = new RefreshCommand(RefreshGrid);
            SeeInfoCommand = new SeeInfoCommand(this);
            EditBidCommand = new OpenItemCommand(this);
            BuyItemCommand = new BuyItemCommand(this);
            Buy += BuyItem;
        }
        public BidViewModel(UserDTO user, BidDTO bid, IAuctionManager aucmanager)
        {
            this.aucmanager = aucmanager;
            this.Good = aucmanager.GetGoodById(bid.good_id);
            this.user = user;
            this.currentBid = bid;
            BidList = aucmanager.GetGoodsBids(Good);
            RefreshBidCommand = new RefreshCommand(RefreshGrid);
            SeeInfoCommand = new SeeInfoCommand(this);
            EditBidCommand = new OpenItemCommand(this);
            BuyItemCommand = new BuyItemCommand(this);
            Buy += BuyItem;
        }
        public void RefreshGrid()
        {
            BidList = aucmanager.GetGoodsBids(Good);
            currentBid = BidList.Find(b => b.user_id == user.user_id);
        }
        public BidWithValidation ReturnCorrectBid()
        {
            return new BidWithValidation(Good, user, aucmanager);
        }
        public void BuyItem()
        {
            BoughtGoodDTO bgood = new BoughtGoodDTO(Good.goodsName, Good.goodsDesc, Good.startPrice, currentBid.bid, user.user_id);
            aucmanager.BuyItem(Good, bgood);
        }
    }
}
