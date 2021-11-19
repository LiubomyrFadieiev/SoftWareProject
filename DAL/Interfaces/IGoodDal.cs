using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IGoodDal
    {
        public List<GoodDTO> GetAllGoods();
        public GoodDTO GetGoodByID(int id);
        public int CreateGood(GoodDTO good);
        public int ChangeGoodName(int good_id, string name);
        public int DeleteGood(int id);
    }
}
