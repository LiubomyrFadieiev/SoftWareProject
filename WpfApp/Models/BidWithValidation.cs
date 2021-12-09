using BusinessLogic.Interfaces;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using WpfApp.Commands;

namespace WpfApp.Models
{
    //public class CustomConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        double number = 0;
    //        try
    //        {
    //            var strValue = (string)value;
    //            Double.TryParse(strValue, out number);
    //            return number;
    //        }
    //        catch(InvalidCastException ex)
    //        {
    //            return value;
    //        }
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return DependencyProperty.UnsetValue;
    //    }
    //}
    public class BidWithValidation : IDataErrorInfo, INotifyPropertyChanged
    {
        private IAuctionManager manager;
        private int good_id;
        private int user_id;
        private double startPrice;
        private string goodName;
        public string GoodName
        {
            get => goodName;
            set
            {
                goodName = value;
                OnPropertyChanged(nameof(GoodName));
            }
        }
        private double bid;
        public double Bid
        {
            get => bid;
            set
            {
                bid = value;
                OnPropertyChanged(nameof(Bid));
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Bid":
                        if (Bid < 0)
                        {
                            error = "Bid cannot be lower than zero.";
                        }
                        else if (Bid <= startPrice)
                        {
                            error = "Your bid is lower than start price of this item.";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public Action Close;
        public CloseCommand CloseCommand { get; }
        public Action Submit;
        public SubmitCommand SubmitCommand { get; }

        public BidWithValidation(GoodDTO good, UserDTO user, IAuctionManager aucManager)
        {
            this.user_id = user.user_id;
            this.good_id = good.good_id;
            this.manager = aucManager;
            this.GoodName = good.goodsName;
            this.startPrice = good.startPrice;
            this.Bid = good.startPrice;
            CloseCommand = new CloseCommand(this);
            SubmitCommand = new SubmitCommand(this);
            if (manager.GetGoodsBids(good).Exists(b => b.user_id == user_id))
            {
                this.Bid = manager.GetGoodsBids(good).Find(b => b.user_id == user_id).bid;
                Submit += () => manager.UpdateBid(Bid, good_id, user_id);
            }
            else
            {
                this.Bid = startPrice;
                Submit += () => manager.InsertBid(new BidDTO(user_id, good_id, Bid));
            }
        }
    }
}
