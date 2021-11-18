using System;
using System.Collections.Generic;
using System.Text;
using DAL.DTO;
using DAL.Realization;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Realization
{
    public class AuctionManager : IAuctionManager
    {
        UserDal uDal;
        GoodDal gDal;
        BidDal bDal;
        BoughtGoodDal bgDal;
        public AuctionManager(string connString)
        {
            uDal = new UserDal(connString);
            gDal = new GoodDal(connString);
            bDal = new BidDal(connString);
            bgDal = new BoughtGoodDal(connString);
        }

        public List<GoodDTO> GetAllGoods()
        {
            return gDal.GetAllGoods();
        }

        public List<GoodDTO> GetSearchedGoods(string search, string type)
        {
            List<GoodDTO> allGoods = gDal.GetAllGoods();
            
            List<GoodDTO> searchedGoods = new List<GoodDTO>();
            if (type == "Name")
            {
                searchedGoods = allGoods.FindAll(u => u.goodsName.Contains(search));
            }
            else if (type == "Description")
            {
                searchedGoods = allGoods.FindAll(u => u.goodsDesc.Contains(search));
            }

            return searchedGoods;
        }
        public GoodDTO GetGoodById(int id)
        {
            return gDal.GetGoodByID(id);
        }
        public List<BidDTO> GetGoodsBids(GoodDTO good)
        {
            List<BidDTO> bids = bDal.GetAllBids();
            return bids.FindAll(b => b.good_id == good.good_id);
        }
        public List<BidDTO> GetUsersBids(UserDTO user)
        {
            List<BidDTO> bids = bDal.GetAllBids();
            return bids.FindAll(b => b.user_id == user.user_id);
        }

        public UserDTO GetAuthorisedUser(string login)
        {
            return uDal.GetUserByLogin(login);
        }

        public bool InsertBid(double price, int goodid, int userid)
        {
            BidDTO bid = new BidDTO(userid, goodid, price);
            return bDal.CreateBid(bid) > 0;
        }

        public bool UpdateBid(double price, int goodid, int userid)
        {
            return bDal.ChangeBid(userid, goodid, price) > 0;
        }
        public bool BuyItem(GoodDTO good, UserDTO buyer, double price)
        {
            BoughtGoodDTO bgood = new BoughtGoodDTO(good.goodsName, good.goodsDesc, good.startPrice, price, buyer.user_id);
            return bgDal.ChangeGoodState(bgood, good) > 0;
        }
        public List<BoughtGoodDTO> GetUsersGoods(UserDTO user)
        {
            List<BoughtGoodDTO> bgoods = bgDal.GetAllBGoods();
            return bgoods.FindAll(u => u.user_id == user.user_id);
        }
    }
}
