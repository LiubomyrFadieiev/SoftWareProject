using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    interface IBoughtGoodDal
    {
        public List<BoughtGoodDTO> GetAllBGoods();
        public BoughtGoodDTO GetBGoodByID(int id);
        public int CreateBGood(BoughtGoodDTO good);
        public int ChangeBGoodUser(int bgood_id, int user_id);
        public int DeleteBGood(int id);
    }
}
