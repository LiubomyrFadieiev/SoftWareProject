using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    interface IBidDal
    {
        public List<BidDTO> GetAllBids();
        public BidDTO GetBidById(int id);
        public int CreateBid(BidDTO bid);
        public int ChangeBid(int user_id, int good_id, double price);
        public int DeleteBid(int user_id, int good_id);
    }
}
