using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public enum GoodInfo
    {
        name = 0,
        description = 1,
        startPrice = 2,
        numberOfProperties = 3,
    }
    public class GoodDTO
    {
        public int good_id { get; set; }
        public string goodsName { get; set; }
        public string goodsDesc { get; set; }
        public double startPrice { get; set; }
        public DateTime insertTime { get; set; }
        public DateTime lastUpdateTime { get; set; }

        public GoodDTO(int id, string name, string desc, double price, DateTime inTime, DateTime luTime)
        {
            good_id = id;
            goodsName = name;
            goodsDesc = desc;
            startPrice = price;
            insertTime = inTime;
            lastUpdateTime = luTime;
        }
        public GoodDTO(string name, string desc, double price)
        {
            goodsName = name;
            goodsDesc = desc;
            startPrice = price;
        }
    }
}
