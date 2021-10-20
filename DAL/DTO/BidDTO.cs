using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class BidDTO
    {
        public int user_id { get; set; }
        public object[] userInformation { get; set; }
        public int good_id { get; set; }
        public object[] goodInformation { get; set; }
        public double bid { get; set; }
        public DateTime insertTime { get; set; }
        public DateTime lastUpdateTime { get; set; }
        public BidDTO(object[] user, object[] good, int userID, int goodID, double bidprice, DateTime inTime, DateTime luTime)
        {

            userInformation = new object[(int)UserInfo.numberOfProperties];
            goodInformation = new object[(int)GoodInfo.numberOfProperties];
            user_id = userID;
            userInformation[(int)UserInfo.firstName] = user[(int)UserInfo.firstName];
            userInformation[(int)UserInfo.lastName] = user[(int)UserInfo.lastName];
            good_id = goodID;
            goodInformation[(int)GoodInfo.name] = good[(int)GoodInfo.name];
            goodInformation[(int)GoodInfo.description] = good[(int)GoodInfo.description];
            goodInformation[(int)GoodInfo.startPrice] = good[(int)GoodInfo.startPrice];
            bid = bidprice;
            insertTime = inTime;
            lastUpdateTime = luTime;
        }
        public BidDTO(int userID, int goodID, double bidprice)
        {
            user_id = userID;
            good_id = goodID;
            bid = bidprice;
        }
    }

}
