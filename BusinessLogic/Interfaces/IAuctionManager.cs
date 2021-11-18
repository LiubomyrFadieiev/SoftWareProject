using System;
using System.Collections.Generic;
using System.Text;
using DAL.DTO;
using DAL.Realization;

namespace BusinessLogic.Interfaces
{
    public interface IAuctionManager
    {
        public UserDTO GetAuthorisedUser(string login);
        public List<GoodDTO> GetAllGoods();
        public List<GoodDTO> GetSearchedGoods(string search, string type);
        public GoodDTO GetGoodById(int id);
        public List<BidDTO> GetGoodsBids(GoodDTO good);
        public List<BidDTO> GetUsersBids(UserDTO user);
        public bool InsertBid(double price, int goodid, int userid);
        public bool UpdateBid(double price, int goodid, int userid);
        public bool BuyItem(GoodDTO good, UserDTO buyer, double price);
        public List<BoughtGoodDTO> GetUsersGoods(UserDTO user);
    }
}
