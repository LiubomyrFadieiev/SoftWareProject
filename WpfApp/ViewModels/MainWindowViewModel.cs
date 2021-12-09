using BusinessLogic.Interfaces;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.Commands;

namespace WpfApp.ViewModels
{
    public partial class MainWindowViewModel : INotifyPropertyChanged
    {
        private string searchString;
        public string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }
        private string type;
        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        private List<GoodDTO> goodList;
        public List<GoodDTO> GoodList
        {
            get => goodList;
            set
            {
                goodList = value;
                OnPropertyChanged(nameof(GoodList));
            }
        }
        public GoodDTO SelectedGood { set; get; }
        public BidDTO SelectedBid { set; get; }
        public TabItem SelectedTab { set; get; }
        // Commands functionality
        public Action OpenFromGoods { get; set; }
        public Action OpenFromBids { get; set; }
        public Action Search { get; set; }
        public Action LogOut { get; set; }
        public SearchCommand SearchCommand { get; set; }
        public OpenItemCommand ShowGoodBids { get; }
        public RefreshCommand RefreshGoods { get; }
        public LogOutCommand LogOutCommand { get; }
        public void SearchItems()
        {
            // Type gets "{"System.Windows.Controls.ComboBoxItem: Type"}"
            if (SearchString.Length == 0 || Type == "")
            {
                GoodList = auctionManager.GetAllGoods();
            }
            else
            {
                Type = TrimComboBoxItem(Type);
                GoodList = auctionManager.GetSearchedGoods(SearchString.Trim(), Type);
            }
        }
        private string TrimComboBoxItem(string cbItem)
        {
            if (!Type.Contains("ComboBoxItem"))
            {
                return cbItem;
            }
            return cbItem.Split(':')[1].Trim();
        }
        public BidViewModel ReturnBidModelFromGoods()
        {
            return new BidViewModel(SelectedGood, user, auctionManager);
        }
        public BidViewModel ReturnBidModelFromBids()
        {
            return new BidViewModel(user, SelectedBid, auctionManager);
        }
        // Managers and UserDTO
        private readonly IAuctionManager auctionManager;
        public UserDTO user;

        // Properties and INotifyPropertyChanged
        private string greetings;
        public string Greetings
        {
            get => greetings;
            set
            {
                greetings = value;
                OnPropertyChanged(nameof(Greetings));
            }
        }
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
        private List<BoughtGoodDTO> bgoodList;
        public List<BoughtGoodDTO> BGoodList
        {
            get => bgoodList;
            set
            {
                bgoodList = value;
                OnPropertyChanged(nameof(BGoodList));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        // Commands functionality
        public RefreshCommand RefreshBids { get; }
        public RefreshCommand RefreshBGoods { get; }
        // Constructor and misc.
        public MainWindowViewModel(UserDTO user, IAuctionManager auctionManager)
        {
            this.user = user;
            this.auctionManager = auctionManager;

            SearchString = "";
            Type = "";

            GoodList = auctionManager.GetAllGoods();
            BidList = auctionManager.GetUsersBids(user);
            BGoodList = auctionManager.GetUsersGoods(user);

            SearchCommand = new SearchCommand(this);
            Search = SearchItems;
            ShowGoodBids = new OpenItemCommand(this);
            LogOutCommand = new LogOutCommand(this);

            RefreshGoods = new RefreshCommand(() => { GoodList = auctionManager.GetAllGoods(); });
            RefreshBids = new RefreshCommand(() => { BidList = auctionManager.GetUsersBids(user); });
            RefreshBGoods = new RefreshCommand(() => { BGoodList = auctionManager.GetUsersGoods(user); });
            greetings = $"Hello, {user.firstName} {user.lastName}!";
        }
    }
}
