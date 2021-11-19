using System;
using System.Collections.Generic;
using System.Text;
using DAL.DTO;
using DAL.Interfaces;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Realization
{
    public class AuctionManager : IAuctionManager
    {
        IUserDal uDal;
        IGoodDal gDal;
        IBidDal bDal;
        IBoughtGoodDal bgDal;
        public AuctionManager(IUserDal userDal, IGoodDal goodDal, IBidDal bidDal, IBoughtGoodDal boughtGoodDal)
        {
            uDal = userDal;
            gDal = goodDal;
            bDal = bidDal;
            bgDal = boughtGoodDal;
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
        public bool InsertBid(BidDTO bid)
        {
            return bDal.CreateBid(bid) > 0;
        }

        public bool UpdateBid(double price, int goodid, int userid)
        {
            return bDal.ChangeBid(userid, goodid, price) > 0;
        }
        public bool BuyItem(GoodDTO good, BoughtGoodDTO bgood)
        {
            return bgDal.ChangeGoodState(bgood, good) > 0;
        }
        public UserDTO GetAuthorisedUser(string login)
        {
            return uDal.GetUserByLogin(login);
        }

        public List<BoughtGoodDTO> GetUsersGoods(UserDTO user)
        {
            List<BoughtGoodDTO> bgoods = bgDal.GetAllBGoods();
            return bgoods.FindAll(u => u.user_id == user.user_id);
        }
    }
}
