using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class BoughtGoodDTO
    {
        private const int NumberOfProperties = 2;
        public int bgood_id { get; set; }
        public string goodsName { get; set; }
        public string goodsDesc { get; set; }
        public double startPrice { get; set; }
        public double endPrice { get; set; }
        public int user_id { get; set; }
        public object[] userInformation { get; set; }
        public DateTime insertTime { get; set; }
        public DateTime lastUpdateTime { get; set; }

        public BoughtGoodDTO(int id, string name, string desc, double start, double end, int userID, object[] list, DateTime inTime, DateTime liTime)
        {
            bgood_id = id;
            goodsName = name;
            goodsDesc = desc;
            startPrice = start;
            endPrice = end;
            user_id = userID;
            userInformation = new object[(int)UserInfo.numberOfProperties];
            userInformation[(int)UserInfo.firstName] = list[(int)UserInfo.firstName];
            userInformation[(int)UserInfo.lastName] = list[(int)UserInfo.lastName];
            insertTime = inTime;
            lastUpdateTime = liTime;
        }
        public BoughtGoodDTO(string name, string desc, double start, double end, int userID)
        {
            goodsName = name;
            goodsDesc = desc;
            startPrice = start;
            endPrice = end;
            user_id = userID;
        }
        public void UpdateInformation(UserDTO user)
        {
            userInformation[(int)UserInfo.firstName] = user.firstName;
            userInformation[(int)UserInfo.lastName] = user.lastName;
        }
    }
}
